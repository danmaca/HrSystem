namespace DanM.Core.Services.Descriptors;

public abstract class DateTimePropertyBase<TDate> : EntityProperty
{
	protected DateTimePropertyBase(Func<string> captionText)
		: base(captionText)
	{
	}

	public TDate GetValue(object entity) => (TDate)ObjectValueGetter(entity);
	public void SetValue(object entity, TDate value) => ObjectValueSetter(entity, value);
}
