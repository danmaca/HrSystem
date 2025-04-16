using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Descriptors;

namespace DanM.Core.Services.Binders;

public abstract class ControlDataBinder : IControlDataBinder
{
	public virtual void BindProperty(BindingContextBase context, ControlData data, IEntityProperty property)
	{
		if (context is DetailBindingContext detailCtx)
		{
			data.IsEditable = detailCtx.Workflow.PropertyIsEditable(property, detailCtx.WorkflowRequest);
		}
	}
}

public interface IControlDataBinder
{
}