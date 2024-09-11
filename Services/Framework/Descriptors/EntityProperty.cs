using DanM.HrSystem.Services.Framework.Binders;

namespace DanM.HrSystem.Services.Framework.Descriptors;

public class EntityProperty : IEntityProperty
{
	public Func<string> CaptionText { get; set; }
	public Func<object, object> ObjectValueGetter { get; set; }
	public Action<object, object> ObjectValueSetter { get; set; }

	public EntityProperty(Func<string> captionText)
	{
		this.CaptionText = captionText;
	}

	public string GetCaptionText(BindingContext context)
	{
		return this.CaptionText();
	}
}

public interface IEntityProperty
{
	Func<string> CaptionText { get; set; }
	Func<object, object> ObjectValueGetter { get; set; }
	Action<object, object> ObjectValueSetter { get; set; }

	string GetCaptionText(BindingContext context);
}