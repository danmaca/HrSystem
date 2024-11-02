using DanM.Core.Contracts.Workflows;
using DanM.Core.Services.Common;

namespace DanM.Core.Services.Workflows;

public class AllowedTransitionsResult
{
	public List<WorkflowTransitionInfo> Transitions { get; } = new List<WorkflowTransitionInfo>();
}

public class RunTransitionResult
{
	public WorkflowRequest Request { get; init; }
	public ResultInfo Result { get; } = new ResultInfo();
	public WorkflowDialog ChangeToDialog { get; set; }
}