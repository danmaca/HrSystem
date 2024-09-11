using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Services.Framework.Descriptors;

namespace DanM.HrSystem.Services.Framework.Binders;

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