using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Web.Client.FwPages;

public partial class DatailMasterpage
{
	[Parameter] public DetailControllerData Data { get; set; }
	[Parameter] public RenderFragment ContenTemplate { get; set; }
}