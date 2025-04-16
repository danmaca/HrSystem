using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Descriptors;

namespace DanM.Core.Services.Binders;

public abstract class CaptionControlDataBinder : ControlDataBinder
{
	public override void BindProperty(BindingContextBase context, ControlData data, IEntityProperty property)
	{
		base.BindProperty(context, data, property);

		if (data is CaptionControlData capData)
		{
			capData.CaptionText = property.GetCaptionText(context);
		}
	}
}