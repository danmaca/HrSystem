using DanM.HrSystem.Primitives.Common;

namespace DanM.Core.Contracts.Workflows;

public class WorkflowQuery : StringEnum<WorkflowQuery>
{
	public static WorkflowQuery PropertyEditing { get; } = new WorkflowQuery();

	private WorkflowQuery()
	{
	}
	static WorkflowQuery() => InitializeEnum();
}