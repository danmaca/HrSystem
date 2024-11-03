using System.ComponentModel;

namespace DanM.Core.Services.Descriptors;

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
		var descProps = TypeDescriptor.GetProperties(GetType()).OfType<PropertyDescriptor>().ToArray();

		foreach (var descProp in descProps)
		{
			var descPropObject = descProp.GetValue(this) as IEntityProperty;
			if (descPropObject != null)
			{
				string descPropName = descProp.Name;

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