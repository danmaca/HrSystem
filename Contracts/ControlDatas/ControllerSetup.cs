using DanM.Core.Contracts.Framework.Navigation;

namespace DanM.Core.Contracts.ControlDatas;

public class ControllerSetup
{
	public NavigationQuery Navigation { get; set; }
	public bool IsPostback { get; set; }
}