using DanM.Core.Contracts.Workflows;

namespace DanM.Core.Contracts.ControlDatas;

public class ActionButtonizerData : ControlData
{
	public WorkflowDialog CurrentDialog { get; set; }
	public List<ActionButtonDto> Actions { get; set; } = new List<ActionButtonDto>();
}