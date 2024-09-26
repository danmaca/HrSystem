namespace DanM.HrSystem.Primitives.Utils;

public static class NameConventionResolver
{
	private const string PageData_Suffix = "Data";
	private const string PageData_Namespace_Contracts = "Contracts";
	private const string PageController_Suffix = "Controller";
	private const string PageController_Namespace_Facades = "Facades";

	public static string TranslateDataToController(string dataType)
	{
		if (dataType.EndsWith(PageData_Suffix))
		{
			string name = dataType.Substring(dataType.LastIndexOf(".") + 1);
			name = name.Substring(0, name.Length - PageData_Suffix.Length);

			string nameSpace = dataType.Substring(0, dataType.LastIndexOf("."));
			nameSpace = nameSpace.Replace("." + PageData_Namespace_Contracts + ".", "." + PageController_Namespace_Facades + ".");

			return nameSpace + ".I" + name + PageController_Suffix;
		}
		return null;
	}
}
