using DanM.Core.Services.Controllers;
using DanM.Core.Services.Workflows;
using DanM.HrSystem.Model.Framework;

namespace DanM.Core.Services.Binders;

public class BindingContext
{
	public BindingMode Mode { get; init; }
	public IEntity BindingEntity { get; set; }
	public WorkflowRequest WorkflowRequest { get; set; }
	public WorkflowBase Workflow { get; set; }
	public IControllerBase Controller { get; init; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
