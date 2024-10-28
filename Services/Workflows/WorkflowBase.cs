namespace DanM.HrSystem.Services.Workflows;

public abstract class WorkflowBase
{
	public List<WorkflowTransition> Transitions { get; } = new List<WorkflowTransition>();

	protected WorkflowBase()
	{
		this.OnCreateTransitions();
	}

	protected virtual void OnCreateTransitions()
	{
	}

	public AllowedTransitionsResult ResolveAllowedTransitions(WorkflowRequest request)
	{
		var result = new AllowedTransitionsResult();
		foreach (var transition in this.Transitions)
		{
			var tranInfo = transition.IsAvailable(request);
			if (tranInfo.Result.IsValid)
				result.Transitions.Add(tranInfo);
		}
		return result;
	}
}