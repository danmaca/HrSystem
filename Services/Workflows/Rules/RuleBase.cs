﻿using DanM.HrSystem.Services.Common;

namespace DanM.HrSystem.Services.Workflows.Rules;

public abstract class RuleBase
{
	public virtual ResultInfo ValidateRule(WorkflowRequest request)
	{
		var result = new ResultInfo();
		OnValidateRule(result, request);
		return result;
	}

	protected abstract void OnValidateRule(ResultInfo result, WorkflowRequest request);
}