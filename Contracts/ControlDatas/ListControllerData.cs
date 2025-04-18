namespace DanM.Core.Contracts.ControlDatas;

public abstract class ListControllerData : ControllerData<ListControllerSetup>
{
	public ListControlData lstMainGrid { get; set; } = new ListControlData();
	public FilterPanelData pnlMainFilter { get; set; } = new FilterPanelData();
}