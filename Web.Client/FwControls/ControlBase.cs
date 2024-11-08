namespace DanM.Core.Web.Client.FwControls;

public class ControlBase : ComponentBase, IControlBase
{
	[CascadingParameter(Name = "PageShare")]
	public PageShareObject PageShare { get; set; }
}

public interface IControlBase
{
}