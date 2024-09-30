using DanM.HrSystem.Contracts.Framework.Navigation;

namespace DanM.HrSystem.Contracts.ControlDatas;

public class ControllerSetup
{
	public NavigationQuery Navigation { get; set; }
	public bool IsPostback { get; set; }
}