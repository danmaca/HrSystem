using System.Reflection;

namespace DanM.HrSystem.Primitives.Utils;

public static class MethodHelper
{
	public static void Invoke(object target, string methodName, params object[] arguments)
	{
		Type targetType = target.GetType();
		MethodInfo methodInfo = targetType.GetMethod(methodName);
		if (methodInfo == null)
			throw new ArgumentException($"Method '{methodName}' not found on type '{targetType.Name}'.");

		MethodInfo genericMethod = methodInfo.MakeGenericMethod(arguments.Select(obj => obj.GetType()).ToArray());
		genericMethod.Invoke(target, arguments);
	}

	public static MethodInfo FindMethod(Type targetType, string methodName)
	{
		var method = targetType.GetMethod(methodName);
		if (method == null)
			method = targetType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Where(obj => obj.Name.Contains(methodName, StringComparison.InvariantCultureIgnoreCase)).Single();
		return method;
	}
}
