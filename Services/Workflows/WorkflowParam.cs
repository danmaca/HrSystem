using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Model.Framework;

namespace DanM.Core.Services.Workflows;

public class WorkflowRequest
{
	public WorkflowDialog Dialog { get; set; }
	public IEntity WorkflowEntity { get; set; }
	public IEntity BindingEntity { get; set; }
	public string TransitionKey { get; set; }
}