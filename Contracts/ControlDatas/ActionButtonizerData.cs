namespace DanM.Core.Contracts.ControlDatas;

public class ActionButtonizerData : ControlData
{
	public List<ActionButtonDto> Actions { get; set; } = new List<ActionButtonDto>();
}