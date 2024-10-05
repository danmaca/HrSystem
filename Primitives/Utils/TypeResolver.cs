using System.Reflection;

namespace DanM.HrSystem.Primitives.Utils;

public static class TypeResolver
{
	private static List<Assembly> _preferredAssemblies = new List<Assembly>();

	public static Type GetType(string typeName)
	{
		foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			Type type = assembly.GetType(typeName);
			if (type != null)
				return type;
		}

		foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			Type type = assembly.GetType(typeName);
			if (type != null)
			{
				if (_preferredAssemblies.Contains(assembly) == false)
					_preferredAssemblies.Add(assembly);
				return type;
			}
		}
		return null;
	}
}
