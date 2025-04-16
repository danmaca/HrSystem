using DanM.Core.Model.Framework;
using DanM.Core.Services.Controllers;
using DanM.HrSystem.Primitives.Common;

namespace DanM.Core.Services.Binders;

public abstract class BindingContextBase
{
	public BindingMode Mode { get; init; }
	public IBindableEntity BindingEntity { get; set; }
	public IControllerBase Controller { get; init; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
