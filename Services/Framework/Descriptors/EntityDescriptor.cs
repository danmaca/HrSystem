using System.ComponentModel;

namespace DanM.HrSystem.Services.Framework.Descriptors;

public class EntityDescriptor
{
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
		var descProps = TypeDescriptor.GetProperties(GetType()).OfType<PropertyDescriptor>();

		foreach (var descProp in descProps)
		{
			var descPropObject = descProp.GetValue(this) as IEntityProperty;
			if (descPropObject != null)
			{
				var entityPropObject = entityProps.FirstOrDefault(obj => obj.Name == descProp.Name);
				if (entityPropObject != null)
				{
					descPropObject.ObjectValueGetter = obj => entityPropObject.GetValue(obj);
					descPropObject.ObjectValueSetter = (obj, value) => entityPropObject.SetValue(obj, value);
				}
			}
		}
	}
}