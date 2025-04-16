using DanM.Core.Services.Binders;

namespace DanM.Core.Services.Descriptors;

public class EntityProperty : IEntityProperty
{
	public Func<string> CaptionText { get; set; }
	public Func<object, object> ObjectValueGetter { get; set; }
	public Action<object, object> ObjectValueSetter { get; set; }

	public EntityProperty(Func<string> captionText)
	{
		CaptionText = captionText;
	}

	public string GetCaptionText(BindingContextBase context)
	{
		return CaptionText();
	}
}

public interface IEntityProperty
{
	Func<string> CaptionText { get; set; }
	Func<object, object> ObjectValueGetter { get; set; }
	Action<object, object> ObjectValueSetter { get; set; }

	string GetCaptionText(BindingContextBase context);
}