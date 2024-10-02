namespace DanM.Core.Contracts.ControlDatas;

public abstract class ControllerData<TSetup> : ControllerData, IControllerData
	where TSetup : ControllerSetup, new()
{
	public ActionButtonizerData conActionButtonizer { get; set; } = new ActionButtonizerData();
	public TSetup Setup { get; set; } = new TSetup();

	ControllerSetup IControllerData.Setup => this.Setup;
}

public abstract class ControllerData
{
}

public interface IControllerData
{
	ActionButtonizerData conActionButtonizer { get; set; }
	ControllerSetup Setup { get; }
}