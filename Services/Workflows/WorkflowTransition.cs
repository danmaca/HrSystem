﻿using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Services.Common;
using DanM.HrSystem.Services.Workflows.Operations;
using DanM.HrSystem.Services.Workflows.Rules;

namespace DanM.HrSystem.Services.Workflows;

public class WorkflowTransition
{
	public string Key { get; set; }
	public string Name { get; set; }
	public List<RuleBase> ButtonRules { get; } = new List<RuleBase>();
	public List<RuleBase> ActionRules { get; } = new List<RuleBase>();
	public List<TransitionOperationBase> Operations { get; } = new List<TransitionOperationBase>();
	public WorkflowDialog ChangeToDialog { get; set; }

	public WorkflowTransitionInfo IsAvailable(WorkflowRequest request)
	{
		var transResult = new ResultInfo();
		foreach (var rule in this.ButtonRules)
		{
			var ruleResult = rule.ValidateRule(request);
			transResult.AddResult(ruleResult);
			if (ruleResult.IsValid == false)
				break;
		}
		return new WorkflowTransitionInfo(this, transResult);
	}

	public void RunOperations(RunTransitionResult runResult)
	{
		foreach (var operation in this.Operations)
		{
			operation.RunOperation(runResult);
		}
	}

	public WorkflowTransition WithDialogRequiredRule(WorkflowDialog dialog)
	{
		this.ButtonRules.Insert(0, new DialogRequiredRule(dialog));
		return this;
	}
}