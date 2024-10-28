namespace DanM.HrSystem.Services.Workflows;

public class AllowedTransitionsResult
{
	public List<WorkflowTransitionInfo> Transitions { get; } = new List<WorkflowTransitionInfo>();
}