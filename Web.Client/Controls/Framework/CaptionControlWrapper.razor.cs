namespace DanM.HrSystem.Web.Client.Controls.Framework;

public partial class CaptionControlWrapper
{
	[Parameter] public ICaptionControlBase CaptionControl { get; set; }
	[Parameter] public RenderFragment ElementContent { get; set; }
}