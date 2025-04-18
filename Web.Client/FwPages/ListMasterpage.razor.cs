using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Web.Client.FwPages;

public partial class ListMasterpage
{
	[Parameter] public ListControllerData Data { get; set; }
	[Parameter] public RenderFragment TitlePanel { get; set; }
	[Parameter] public RenderFragment FilterPanel { get; set; }
	[Parameter] public RenderFragment ContenTemplate { get; set; }
}