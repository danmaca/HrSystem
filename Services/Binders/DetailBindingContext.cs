using DanM.Core.Services.Workflows;

namespace DanM.Core.Services.Binders;

public class DetailBindingContext : BindingContextBase
{
	public WorkflowRequest WorkflowRequest { get; set; }
	public WorkflowBase Workflow { get; set; }
}