namespace DanM.HrSystem.Services.Framework.Descriptors;

public class EntityProperty : IEntityProperty
{
	public Func<string> CaptionText { get; set; }
	public Func<object, object> ObjectValueGetter { get; set; }
	public Action<object, object> ObjectValueSetter { get; set; }
}

public interface IEntityProperty
{
	Func<string> CaptionText { get; set; }
	Func<object, object> ObjectValueGetter { get; set; }
	Action<object, object> ObjectValueSetter { get; set; }
}