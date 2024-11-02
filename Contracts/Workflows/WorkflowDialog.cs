using DanM.HrSystem.Primitives.Common;

namespace DanM.Core.Contracts.Workflows;

public class WorkflowDialog : StringEnum<WorkflowDialog>
{
	public static WorkflowDialog Detail { get; } = new WorkflowDialog();
	public static WorkflowDialog Editing { get; } = new WorkflowDialog();

	private WorkflowDialog()
	{
	}
	static WorkflowDialog() => InitializeEnum();
}