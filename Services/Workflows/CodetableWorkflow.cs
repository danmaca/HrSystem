using DanM.Core.Contracts.Workflows;

namespace DanM.HrSystem.Services.Workflows;

public class CodetableWorkflow : WorkflowBase
{
	protected override void OnCreateTransitions()
	{
		base.OnCreateTransitions();

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "Edit",
			Name = "Upravit",
		}
			.WithDialogRequiredRule(WorkflowDialog.Detail));

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "Save",
			Name = "Uložit",
		}
			.WithDialogRequiredRule(WorkflowDialog.Editing));

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "Cancel",
			Name = "Storno",
		}
			.WithDialogRequiredRule(WorkflowDialog.Editing));
	}
}