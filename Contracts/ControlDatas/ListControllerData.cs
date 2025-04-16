namespace DanM.Core.Contracts.ControlDatas;

public abstract class ListControllerData : ControllerData<ListControllerSetup>
{
	public ListControlData gvMainGrid { get; set; }
}