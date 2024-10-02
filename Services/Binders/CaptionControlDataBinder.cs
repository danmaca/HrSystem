using DanM.Core.Contracts.ControlDatas;
using DanM.HrSystem.Services.Descriptors;

namespace DanM.HrSystem.Services.Binders;

public abstract class CaptionControlDataBinder : ControlDataBinder
{
	public override void BindProperty(BindingContext context, ControlData data, IEntityProperty property)
	{
		base.BindProperty(context, data, property);

		if (data is CaptionControlData capData)
		{
			capData.CaptionText = property.GetCaptionText(context);
		}
	}
}