using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Descriptors;

namespace DanM.Core.Services.Binders;

public abstract class ControlDataBinder : IControlDataBinder
{
	public virtual void BindProperty(BindingContext context, ControlData data, IEntityProperty property)
	{
		data.IsEditable = context.Workflow.PropertyIsEditable(property, context.WorkflowRequest);
	}
}

public interface IControlDataBinder
{
}