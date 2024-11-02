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
			ChangeToDialog = WorkflowDialog.Editing,
		}
			.WithDialogRequiredRule(WorkflowDialog.Detail));

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "SaveTest",
			Name = "UložitTEst",
			ChangeToDialog = WorkflowDialog.Detail,
		}
			.WithDialogRequiredRule(WorkflowDialog.Detail));

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "Save",
			Name = "Uložit",
			ChangeToDialog = WorkflowDialog.Detail,
		}
			.WithDialogRequiredRule(WorkflowDialog.Editing));

		this.Transitions.Add(new WorkflowTransition()
		{
			Key = "Cancel",
			Name = "Storno",
			ChangeToDialog = WorkflowDialog.Detail,
		}
			.WithDialogRequiredRule(WorkflowDialog.Editing));
	}
}