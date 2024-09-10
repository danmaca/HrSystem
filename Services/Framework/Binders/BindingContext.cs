namespace DanM.HrSystem.Services.Framework.Binders;

public class BindingContext
{
	public BindingMode Mode { get; set; }
	public object BindingEntity { get; set; }
}

public enum BindingMode
{
	UpdateForm,
	UpdateEntity,
}
