using System.Reflection;

namespace DanM.HrSystem.Primitives.Utils;

public static class MethodInvoker
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
}
