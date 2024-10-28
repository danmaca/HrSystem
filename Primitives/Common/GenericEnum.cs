using System.Reflection;

namespace DanM.HrSystem.Primitives.Common;

public abstract class GenericEnum<TEnum, TValue>
	where TEnum : GenericEnum<TEnum, TValue>
{
	public static bool AllowInstanceExceptions { get; set; }

	public string Name { get; private set; }
	public TValue Value { get; private set; }

	private static readonly List<TEnum> _enums;

	protected GenericEnum()
	{
	}

	static GenericEnum()
	{
		Type enumType = typeof(TEnum);
		Type valueType = typeof(TValue);
		if (enumType == valueType)
			throw new InvalidOperationException($"{enumType.Name} and its underlying type cannot be the same");

		BindingFlags bf = BindingFlags.Static | BindingFlags.Public;
		_enums = new List<TEnum>();

		foreach (PropertyInfo propInfo in enumType.GetProperties(bf))
		{
			if (propInfo.PropertyType == valueType)
			{
				var enumValue = (TEnum)propInfo.GetValue(null);
				enumValue.Name = propInfo.Name;
				enumValue.Initialize();
				_enums.Add(enumValue);
			}
		}
	}

	protected virtual void Initialize()
	{
	}

	public void ChangeValue(TValue value)
	{
		this.Value = value;
	}

	public static string[] GetNames() => _enums.Select(obj => obj.Name).ToArray();
	public static TValue[] GetValues() => _enums.Select(obj => obj.Value).ToArray();

	public static int Count => _enums.Count;
	public static bool IsDefinedName(string name) => _enums.Select(obj => obj.Name).Contains(name);
	public static bool IsDefinedValue(TValue value) => _enums.Select(obj => obj.Value).Contains(value);

	public static TEnum ByName(string name)
	{
		var enumValue = _enums.FirstOrDefault(obj => obj.Name == name);
		if (enumValue == null)
		{
			if (AllowInstanceExceptions)
				throw new ArgumentException($"'{name}' is not a defined name of {typeof(TEnum).Name}");
			return null;
		}
		return enumValue;
	}

	public static TEnum ByValue(TValue value)
	{
		var enumValue = _enums.FirstOrDefault(obj => object.Equals(obj.Value, value));
		if (enumValue == null)
		{
			if (AllowInstanceExceptions)
				throw new ArgumentException($"'{value}' is not a defined value of {typeof(TEnum).Name}");
			return null;
		}
		return enumValue;
	}
}

public abstract class StringEnum<TEnum> : GenericEnum<TEnum, string>
	where TEnum : StringEnum<TEnum>
{
	protected override void Initialize()
	{
		base.Initialize();
		this.ChangeValue(this.Name);
	}
}