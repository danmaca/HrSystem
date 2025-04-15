using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.Core.Services.Binders;

[Service]
public class DateOnlyBinder : CaptionControlDataBinder, IDateOnlyBinder
{
	public void Bind(BindingContext context, DateControlData data, DateOnlyProperty property)
	{
		this.BindProperty(context, data, property);

		switch (context.Mode)
		{
			case BindingMode.UpdateForm:
				data.SelectedDateOnly = property.GetValue(context.BindingEntity);
				break;

			case BindingMode.UpdateEntity:
				property.SetValue(context.BindingEntity, data.SelectedDateOnly);
				break;
		}
	}
}

public interface IDateOnlyBinder
{
	void Bind(BindingContext context, DateControlData data, DateOnlyProperty property);
}