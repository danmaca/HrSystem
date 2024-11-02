using DanM.Core.Contracts.Workflows;
using DanM.Core.Services.Descriptors;
using DanM.Core.Services.Workflows;

namespace DanM.Core.Services.Workflows.Internals;

public class WorkflowQueryDefinition
{
	public List<WorkflowQuery> CommonQueries { get; } = new List<WorkflowQuery>();
	public WorkflowBase Workflow { get; init; }

	public bool? IsQueryValid(IEntityProperty property, WorkflowRequest wfRequest)
	{
		if (this.CommonQueries.Any())
		{
			foreach (var query in this.CommonQueries)
			{
				if (this.Workflow.IsQueryValid(query, wfRequest))
					return true;
			}
			return false;
		}
		return null;
	}
}
