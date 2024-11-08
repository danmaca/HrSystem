namespace DanM.Core.Web.Client.FwControls;

public partial class CaptionControlWrapper
{
	[Parameter] public ICaptionControlBase CaptionControl { get; set; }
	[Parameter] public RenderFragment ElementContent { get; set; }
}