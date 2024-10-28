using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Services.Common;

namespace DanM.HrSystem.Services.Workflows.Rules;

public class DialogRequiredRule : RuleBase
{
	private WorkflowDialog _requiredDialog;

	public DialogRequiredRule(WorkflowDialog requiredDialog)
	{
		_requiredDialog = requiredDialog;
	}

	protected override void OnValidateRule(ResultInfo result, WorkflowRequest request)
	{
		if (request.Dialog != _requiredDialog)
			result.AddError($"Not valid dialogue {_requiredDialog.Name} ({request.Dialog?.Name})");
	}
}