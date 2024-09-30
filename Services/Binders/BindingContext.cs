using DanM.HrSystem.Model.Framework;

namespace DanM.HrSystem.Services.Binders;

public class BindingContext
{
	public BindingMode Mode { get; set; }
	public IEntity BindingEntity { get; set; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
