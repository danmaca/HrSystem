using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Services.Framework.Descriptors;

namespace DanM.HrSystem.Services.Framework.Binders;

public abstract class ControlDataBinder : IControlDataBinder
{
	public virtual void BindProperty(BindingContext context, ControlData data, IEntityProperty property)
	{
	}
}

public interface IControlDataBinder
{
}