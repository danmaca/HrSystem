using DanM.Core.Primitives.Common;
using DanM.Core.Services.Controllers;

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
