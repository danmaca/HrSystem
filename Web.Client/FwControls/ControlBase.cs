using DanM.HrSystem.Web.Client.Infrastructure.Rendering;

namespace DanM.HrSystem.Web.Client.FwControls;

public class ControlBase : ComponentBase, IControlBase
{
	[CascadingParameter(Name = "PageShare")]
	public PageShareObject PageShare { get; set; }
}

public interface IControlBase
{
}