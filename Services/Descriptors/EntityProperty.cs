using DanM.HrSystem.Services.Binders;

namespace DanM.HrSystem.Services.Descriptors;

public class EntityProperty : IEntityProperty
{
	public Func<string> CaptionText { get; set; }
	public Func<object, object> ObjectValueGetter { get; set; }
	public Action<object, object> ObjectValueSetter { get; set; }

	public EntityProperty(Func<string> captionText)
	{
		CaptionText = captionText;
	}

	public string GetCaptionText(BindingContext context)
	{
		return CaptionText();
	}
}

public interface IEntityProperty
{
	Func<string> CaptionText { get; set; }
	Func<object, object> ObjectValueGetter { get; set; }
	Action<object, object> ObjectValueSetter { get; set; }

	string GetCaptionText(BindingContext context);
}