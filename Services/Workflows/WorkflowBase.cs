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

	public RunTransitionResult RunTransition(WorkflowRequest wfRequest)
	{
		var runResult = new RunTransitionResult
		{
			Request = wfRequest,
		};
		var transition = this.Transitions.FirstOrDefault(obj => obj.Key == wfRequest.RunTransitionKey);
		var transAvailInfo = transition.IsAvailable(wfRequest);
		runResult.Result.AddResult(transAvailInfo.Result);

		if (transAvailInfo.Result.IsValid == false)
		{
			runResult.Result.AddError($"Transition {transition.Key} not available");
			return runResult;
		}

		transition.RunOperations(runResult);

		runResult.ChangeToDialog = transition.ChangeToDialog;
		return runResult;
	}
}