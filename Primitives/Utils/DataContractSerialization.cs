using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DanM.HrSystem.Primitives.Utils;

public class DataContractSerialization
{
	private static readonly List<KnownTypeInfo> _knownTypeBases = new List<KnownTypeInfo>();
	private static readonly Dictionary<string, HashSet<Type>> _knownTypes = new Dictionary<string, HashSet<Type>>();

	private static readonly List<KnownTypeGenericMemberInfo> _knownTypeGenericMemberBases = new List<KnownTypeGenericMemberInfo>();

	private static object _locker = new object();
	private static readonly List<Assembly> _loadedAssemblies = new List<Assembly>();
	[ThreadStatic]
	private static bool _isDeserializing;
	[ThreadStatic]
	private static bool _isSerializing;
	[ThreadStatic]
	private static object _initialObjectDeserializing;
	[ThreadStatic]
	private static object _initialObjectSerializing;

	static DataContractSerialization()
	{
		_knownTypes.Add(TypeKind.None.ToString(), new HashSet<Type>());
	}

	public DataContractSerialization(SerializationMethod method)
	{
		Method = method;
	}

	public static bool IsDeserializing
	{
		get { return _isDeserializing; }
		private set { _isDeserializing = value; }
	}
	public static bool IsSerializing
	{
		get { return _isSerializing; }
		private set { _isSerializing = value; }
	}

	public SerializationMethod Method { get; set; }
	public bool LogDeserializationAsError { get; set; } = true;

	public static TData CloneData<TData>(TData data, TypeKind knownTypeKind = TypeKind.None)
	{
		var serialization = new DataContractSerialization(SerializationMethod.Xml);
		using (var stream = serialization.SerializeToStream(data, knownTypeKind))
		{
			try
			{
				if (_initialObjectDeserializing == null)
				{
					_initialObjectDeserializing = stream;
					IsDeserializing = true;
				}

				var serializer = serialization.GetSerializer(data == null ? typeof(TData) : data.GetType(), knownTypeKind.ToString());
				stream.Position = 0;

				if (serializer is XmlObjectSerializer)
					return (TData)((XmlObjectSerializer)serializer).ReadObject(stream);
				else
					return (TData)((DataContractJsonSerializer)serializer).ReadObject(stream);
			}
			finally
			{
				if (object.ReferenceEquals(_initialObjectDeserializing, stream))
				{
					_initialObjectDeserializing = null;
					IsDeserializing = false;
				}
			}
		}
	}

	public TData Deserialize<TData>(string data, TypeKind knownTypeKind)
	{
		return Deserialize<TData>(data, knownTypeKind.ToString());
	}

	public TData Deserialize<TData>(string data, string knownTypeKind)
	{
		using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
		{
			return Deserialize<TData>(stream, knownTypeKind);
		}
	}

	public TData Deserialize<TData>(byte[] data, TypeKind knownTypeKind)
	{
		return Deserialize<TData>(data, knownTypeKind.ToString());
	}

	public TData Deserialize<TData>(byte[] data, string knownTypeKind)
	{
		using (var stream = new MemoryStream(data))
		{
			return Deserialize<TData>(stream, knownTypeKind);
		}
	}

	public TData Deserialize<TData>(MemoryStream stream, TypeKind knownTypeKind)
	{
		return Deserialize<TData>(stream, knownTypeKind.ToString());
	}

	public TData Deserialize<TData>(MemoryStream fromStream, string knownTypeKind)
	{
		MemoryStream outputStream = null;
		try
		{
			if (_initialObjectDeserializing == null)
			{
				_initialObjectDeserializing = fromStream;
				IsDeserializing = true;
			}

			var serializer = GetSerializer(typeof(TData), knownTypeKind);
			fromStream.Position = 0;
			outputStream = fromStream;

			if (serializer is XmlObjectSerializer)
				return (TData)((XmlObjectSerializer)serializer).ReadObject(outputStream);
			else
				return (TData)((DataContractJsonSerializer)serializer).ReadObject(outputStream);
		}
		catch (Exception ex)
		{
			string logText = $"Error while deserializing";

			if (outputStream != null)
			{
				outputStream.Position = 0;
				var streamReader = new StreamReader(outputStream);
				string streamText = streamReader.ReadToEnd();

				logText += $": {typeof(TData).FullName} from: {streamText}";
			}

			throw new ApplicationException(logText, ex);
		}
		finally
		{
			if (object.ReferenceEquals(_initialObjectDeserializing, fromStream))
			{
				_initialObjectDeserializing = null;
				IsDeserializing = false;
			}
		}
	}

	private object GetSerializer(Type dataType, string knownTypeKind)
	{
		switch (Method)
		{
			case SerializationMethod.Xml:
				return new DataContractSerializer(dataType, GetTypes(knownTypeKind));
			case SerializationMethod.Json:
				return new DataContractJsonSerializer(dataType, new DataContractJsonSerializerSettings()
				{
					KnownTypes = GetTypes(knownTypeKind),
					UseSimpleDictionaryFormat = true
				});
			default:
				throw new NotImplementedException();
		}
	}

	public static HashSet<Type> GetTypes(TypeKind kind)
	{
		return GetTypes(kind.ToString());
	}

	public static HashSet<Type> GetTypes(string kind)
	{
		return _knownTypes[kind];
	}

	public static void ReadAssemblyContent(Assembly assembly, KnownTypeInfo info)
	{
		if (_knownTypes.ContainsKey(info.Kind) == false)
			_knownTypes.Add(info.Kind, new HashSet<Type>());

		var infoKnownTypeBase = info.KnownTypeBase;
		var knownTypesCollection = _knownTypes[info.Kind];

		foreach (Type type in assembly.GetTypes())
		{
			if (!type.IsGenericType && infoKnownTypeBase.IsAssignableFrom(type)
				&& (type.IsNested == false || type.IsNestedPublic))
				knownTypesCollection.Add(type);

			foreach (TypeInfo subType in type.GetTypeInfo().DeclaredNestedTypes)
			{
				if (!subType.IsGenericType && subType.IsNestedPublic && infoKnownTypeBase.IsAssignableFrom(subType.AsType()))
					knownTypesCollection.Add(subType.AsType());
			}
		}
	}

	public static void ReadAssemblyGenericMembers(Assembly assembly, KnownTypeGenericMemberInfo info)
	{
		if (_knownTypes.ContainsKey(info.Kind) == false)
			_knownTypes.Add(info.Kind, new HashSet<Type>());

		var infoKnownTypeBase = info.KnownTypeBase;

		foreach (Type type in assembly.GetTypes())
		{
			string name = type.Name;

			if (type.IsGenericType == false && infoKnownTypeBase.IsAssignableFrom(type))
			{
				foreach (var member in type.GetMembers(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy))
				{
					Type memberType = null;

					if (member is PropertyInfo)
						memberType = ((PropertyInfo)member).PropertyType;

					else if (member is FieldInfo)
						memberType = ((FieldInfo)member).FieldType;

					if (memberType != null && info.KnownTypeGenericMember.IsAssignableFrom(memberType))
					{
						_knownTypes[info.Kind].Add(memberType);
					}

				}
			}
		}
	}


	public static void RegisterAdditionalKnownType(KnownTypeInfo info)
	{
		if (_knownTypeBases.Contains(info) == false)
		{
			_knownTypeBases.Add(info);

			foreach (Assembly assembly in _loadedAssemblies)
				ReadAssemblyContent(assembly, info);
		}
	}

	public static void ReadAssemblyContent(Assembly assembly)
	{
		if (_loadedAssemblies.Contains(assembly) == false)
			_loadedAssemblies.Add(assembly);

		foreach (KnownTypeInfo info in _knownTypeBases)
		{
			ReadAssemblyContent(assembly, info);
		}

		foreach (KnownTypeGenericMemberInfo info in _knownTypeGenericMemberBases)
		{
			ReadAssemblyGenericMembers(assembly, info);
		}
	}

	public static void RegisterKnownTypesBase(TypeKind kind, Type knownTypeBase)
	{
		RegisterKnownTypesBase(kind.ToString(), knownTypeBase);
	}

	private static void RegisterKnownTypesBase(string kind, Type knownTypeBase)
	{
		var info = new KnownTypeInfo
		{
			Kind = kind,
			KnownTypeBase = knownTypeBase
		};

		if (_knownTypeBases.Contains(info) == false)
			_knownTypeBases.Add(info);
	}

	public static void RegisterSingleKnownType(TypeKind kind, Type knownType)
	{
		RegisterSingleKnownType(kind.ToString(), knownType);
	}
	private static void RegisterSingleKnownType(string kind, Type knownType)
	{
		_knownTypes[kind].Add(knownType);
	}

	public static void RegisterGenericMemberTypeBase(TypeKind kind, Type allowedClassType, Type genericMemberAncestorType)
	{
		var info = new KnownTypeGenericMemberInfo()
		{
			Kind = kind.ToString(),
			KnownTypeBase = allowedClassType,
			KnownTypeGenericMember = genericMemberAncestorType
		};

		if (_knownTypeGenericMemberBases.Contains(info) == false)
			_knownTypeGenericMemberBases.Add(info);
	}

	public byte[] Serialize(object serializingObject, TypeKind knownTypeKind)
	{
		return Serialize(serializingObject, knownTypeKind.ToString());
	}

	public byte[] Serialize(object serializingObject, string knownTypeKind)
	{
		return SerializeToStream(serializingObject, knownTypeKind).ToArray();
	}

	public MemoryStream SerializeToStream(object serializingObject, TypeKind knownTypeKind)
	{
		return SerializeToStream(serializingObject, knownTypeKind.ToString());
	}

	public MemoryStream SerializeToStream(object serializingObject, string knownTypeKind)
	{
		try
		{
			if (_initialObjectSerializing == null)
			{
				_initialObjectSerializing = serializingObject;
				IsSerializing = true;
			}

			var memoryStream = new MemoryStream();
			var serializer = GetSerializer(serializingObject.GetType(), knownTypeKind);

			if (serializer is XmlObjectSerializer)
				((XmlObjectSerializer)serializer).WriteObject(memoryStream, serializingObject);
			else
				((DataContractJsonSerializer)serializer).WriteObject(memoryStream, serializingObject);

			memoryStream.Position = 0;

			return memoryStream;
		}
		finally
		{
			if (object.ReferenceEquals(_initialObjectSerializing, serializingObject))
			{
				_initialObjectSerializing = null;
				IsSerializing = false;
			}
		}
	}

	public string SerializeToString(object serializingObject, TypeKind knownTypeKind)
	{
		return SerializeToString(serializingObject, knownTypeKind.ToString());
	}

	public string SerializeToString(object serializingObject, string knownTypeKind)
	{
		var stream = this.SerializeToStream(serializingObject, knownTypeKind);
		byte[] source = stream.ToArray();
		return Encoding.UTF8.GetString(source, 0, source.Length);
	}

	public enum SerializationMethod
	{
		Xml,
		Json
	}

	public enum TypeKind
	{
		None,
		Controller,
	}

	public class KnownTypeInfo
	{
		public string Kind { get; set; }

		[IgnoreDataMember]
		public Type KnownTypeBase
		{
			get { return MemberCoder.DecodeFromFullName(KnownTypeBaseName); }
			set { KnownTypeBaseName = MemberCoder.EncodeToFullName(value); }
		}

		public string KnownTypeBaseName { get; set; }

		public override bool Equals(object obj)
		{
			var myObj = obj as KnownTypeInfo;
			return myObj != null && myObj.Kind == Kind && myObj.KnownTypeBase == KnownTypeBase;
		}

		public override int GetHashCode()
		{
			return Kind.GetHashCode() + KnownTypeBase.GetHashCode();
		}
	}

	public class KnownTypeGenericMemberInfo : KnownTypeInfo
	{
		[IgnoreDataMember]
		public Type KnownTypeGenericMember
		{
			get { return MemberCoder.DecodeFromFullName(KnownTypeGenericMemberName); }
			set { KnownTypeGenericMemberName = MemberCoder.EncodeToFullName(value); }
		}

		public string KnownTypeGenericMemberName { get; set; }

		public override bool Equals(object obj)
		{
			var myObj = obj as KnownTypeGenericMemberInfo;
			return myObj != null && base.Equals(obj) && myObj.KnownTypeGenericMember == KnownTypeGenericMember;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ KnownTypeGenericMember.GetHashCode();
		}
	}

	public static class MemberCoder
	{
		public static string Encode(MemberInfo info)
		{
			return EncodeToFullName(info.DeclaringType) + "#$#" + ((int)info.MemberType).ToString() +"#$#" + info.Name;
		}

		public static string EncodeToFullName(Type type)
		{
			return type.FullName + ", " + type.GetTypeInfo().Assembly.GetName().Name;
		}

		public static MemberInfo Decode(string encodedInfo)
		{
			string[] infos = encodedInfo.Split(new[] {"#$#"}, StringSplitOptions.None);
			Type memberType = DecodeFromFullName(infos[0]);

			switch ((MemberTypes)int.Parse(infos[1]))
			{
				case MemberTypes.Property: return memberType.GetProperty(infos[2], BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
				case MemberTypes.Field: return memberType.GetField(infos[2], BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
				case MemberTypes.Method: return memberType.GetMethod(infos[2], BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
			}
			throw new NotSupportedException("not supported member type");
		}

		private static Dictionary<string, Type> _decodedTypesFromFullName = new Dictionary<string, Type>();

		public static Type DecodeFromFullName(string fullName)
		{
			Type type;
			if (_decodedTypesFromFullName.TryGetValue(fullName, out type) == false)
			{
				type = Type.GetType(fullName);
				_decodedTypesFromFullName[fullName] = type;
			}
			return type;
		}

		public static TObject GetObject<TObject>(string encodedInfo)
		{
			MemberInfo memberInfo = Decode(encodedInfo);
			if (memberInfo is FieldInfo)
				return (TObject) ((FieldInfo) memberInfo).GetValue(null);
			else if (memberInfo is PropertyInfo)
				return (TObject) ((PropertyInfo) memberInfo).GetValue(null, null);
			return default(TObject);
		}
	}
}