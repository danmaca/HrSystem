using DanM.Core.Contracts.ControlDatas;
using DanM.HrSystem.Services.Descriptors;

namespace DanM.HrSystem.Services.Binders;

public abstract class ControlDataBinder : IControlDataBinder
{
	public virtual void BindProperty(BindingContext context, ControlData data, IEntityProperty property)
	{
	}
}

public interface IControlDataBinder
{
}