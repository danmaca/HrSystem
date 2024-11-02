namespace DanM.Core.Services.Descriptors;

public class StringProperty : EntityProperty
{
	public int MaxLength { get; set; }

	public StringProperty(Func<string> captionText)
		: base(captionText)
	{

	}

	public string GetValue(object entity) => ObjectValueGetter(entity) as string;
	public void SetValue(object entity, string value) => ObjectValueSetter(entity, value);
}
