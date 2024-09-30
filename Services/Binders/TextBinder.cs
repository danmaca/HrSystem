using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Services.Descriptors;
using Havit.Extensions.DependencyInjection.Abstractions;

namespace DanM.HrSystem.Services.Binders;

[Service]
public class TextBinder : CaptionControlDataBinder, ITextBinder
{
	public void Bind(BindingContext context, TextControlData data, StringProperty property)
	{
		this.BindProperty(context, data, property);

		switch (context.Mode)
		{
			case BindingMode.UpdateForm:
				data.Text = property.GetValue(context.BindingEntity);
				break;

			case BindingMode.UpdateEntity:
				property.SetValue(context.BindingEntity, data.Text);
				break;
		}
	}
}

public interface ITextBinder
{
	void Bind(BindingContext context, TextControlData data, StringProperty property);
}