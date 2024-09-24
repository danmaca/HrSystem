namespace DanM.HrSystem.Contracts.ControlDatas;

public abstract class ControllerData<TSetup> : IControllerData
	where TSetup : ControllerSetup, new()
{
	public ActionButtonizerData conActionButtonizer { get; set; } = new ActionButtonizerData();
	public TSetup Setup { get; set; } = new TSetup();
}

public interface IControllerData
{
	ActionButtonizerData conActionButtonizer { get; set; }
}