using DanM.Core.Services.Common;

namespace DanM.Core.Services.Workflows;

public class WorkflowTransitionInfo
{
	public WorkflowTransition Transition { get; set; }
	public ResultInfo Result { get; set; }

	public WorkflowTransitionInfo(WorkflowTransition transition, ResultInfo result)
	{
		this.Transition = transition;
		this.Result = result;
	}
}