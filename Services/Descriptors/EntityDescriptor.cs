using System.ComponentModel;

namespace DanM.HrSystem.Services.Descriptors;

public class EntityDescriptor
{
	internal const string PropertyAttributeSuffix = "Prop";

	public EntityDescriptor()
	{
		InitializeDescriptor();
	}

	public void InitializeDescriptor()
	{
		OnInitializeDescriptor();
	}

	protected virtual void OnInitializeDescriptor()
	{
	}
}

public class EntityDescriptor<TEntity> : EntityDescriptor
{
	protected override void OnInitializeDescriptor()
	{
		base.OnInitializeDescriptor();

		var entityProps = TypeDescriptor.GetProperties(typeof(TEntity)).OfType<PropertyDescriptor>();
		var descProps = TypeDescriptor.GetProperties(GetType()).OfType<PropertyDescriptor>()
			.Where(obj => obj.Name.EndsWith(PropertyAttributeSuffix))
			.ToArray();

		foreach (var descProp in descProps)
		{
			var descPropObject = descProp.GetValue(this) as IEntityProperty;
			if (descPropObject != null)
			{
				string descPropName = descProp.Name.Substring(0, descProp.Name.Length - PropertyAttributeSuffix.Length);

				var entityPropObject = entityProps.FirstOrDefault(obj => obj.Name == descPropName);
				if (entityPropObject != null)
				{
					descPropObject.ObjectValueGetter = obj => entityPropObject.GetValue(obj);
					descPropObject.ObjectValueSetter = (obj, value) => entityPropObject.SetValue(obj, value);
				}
			}
		}
	}
}