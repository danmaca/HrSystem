using DanM.Core.Contracts.Workflows;
using DanM.Core.Services.Descriptors;
using DanM.HrSystem.Services.Workflows.Internals;

namespace DanM.Core.Services.Workflows;

public abstract class WorkflowBase
{
	public List<WorkflowTransition> Transitions { get; } = new List<WorkflowTransition>();
	public WorkflowQueryDefinition PropertyIsEditableDefinition { get; }

	protected WorkflowBase()
	{
		this.PropertyIsEditableDefinition = new WorkflowQueryDefinition() { Workflow = this };
		this.OnCreateTransitions();
	}

	protected virtual void OnCreateTransitions()
	{
	}

	public AllowedTransitionsResult ResolveAllowedTransitions(WorkflowRequest wfRequest)
	{
		var result = new AllowedTransitionsResult();
		foreach (var transition in this.Transitions)
		{
			var tranInfo = transition.IsAvailable(wfRequest);
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
		var transition = this.Transitions.FirstOrDefault(obj => obj.Key == wfRequest.TransitionKey);
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

	public bool IsQueryValid(WorkflowQuery query, WorkflowRequest wfRequest)
	{
		if (wfRequest.TransitionKey != null)
			return this.Transitions.Where(obj => obj.Key == wfRequest.TransitionKey && obj.IsAvailable(wfRequest).Result.IsValid).Any();

		var allowdResult = this.ResolveAllowedTransitions(wfRequest);

		if (allowdResult.Transitions.Any(obj => obj.Transition.ValidQueries.Contains(query)))
			return true;
		return false;
	}

	public bool PropertyIsEditable(IEntityProperty property, WorkflowRequest wfRequest)
	{
		return this.PropertyIsEditableDefinition.IsQueryValid(property, wfRequest) ?? false;
	}
}