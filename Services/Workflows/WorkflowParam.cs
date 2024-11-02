using DanM.Core.Contracts.Workflows;
using DanM.HrSystem.Model.Framework;

namespace DanM.HrSystem.Services.Workflows;

public class WorkflowRequest
{
	public WorkflowDialog Dialog { get; set; }
	public IEntity WorkflowEntity { get; set; }
	public IEntity BindingEntity { get; set; }
	public string RunTransitionKey { get; set; }
}