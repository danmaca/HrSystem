namespace DanM.Core.Contracts.ControlDatas;

public abstract class ListControllerData : ControllerData<ListControllerSetup>
{
	public ListControlData lstMainGrid { get; set; }
}