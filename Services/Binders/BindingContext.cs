using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Controllers;
using DanM.HrSystem.Model.Framework;
using DanM.HrSystem.Services.Workflows;

namespace DanM.HrSystem.Services.Binders;

public class BindingContext
{
	public BindingMode Mode { get; init; }
	public IEntity BindingEntity { get; set; }
	public WorkflowRequest WorkflowRequest { get; set; }
	public IControllerBase Controller { get; init; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
