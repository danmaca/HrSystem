using DanM.HrSystem.Model.Framework;
using DanM.HrSystem.Services.Workflows;

namespace DanM.HrSystem.Services.Binders;

public class BindingContext
{
	public BindingMode Mode { get; set; }
	public IEntity BindingEntity { get; set; }
	public WorkflowRequest WorkflowRequest { get; set; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
