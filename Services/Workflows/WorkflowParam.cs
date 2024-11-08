using DanM.Core.Contracts.Workflows;
using DanM.Core.Model.Framework;
using Havit.Data.Patterns.UnitOfWorks;

namespace DanM.Core.Services.Workflows;

public class WorkflowRequest
{
	public IUnitOfWork UnitOfWork { get; init; }
	public bool IsNewEntity { get; init; }
	public WorkflowDialog Dialog { get; set; }
	public IEntity WorkflowEntity { get; set; }
	public IEntity BindingEntity { get; set; }
	public string TransitionKey { get; set; }
}