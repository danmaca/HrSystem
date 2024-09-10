namespace DanM.HrSystem.Services.Framework.Descriptors;

public class StringProperty : EntityProperty
{
	public int MaxLength { get; set; }

	public string GetValue(object entity) => ObjectValueGetter(entity) as string;
	public void SetValue(object entity, string value) => ObjectValueSetter(entity, value);
}
