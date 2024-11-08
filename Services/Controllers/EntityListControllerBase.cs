using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Model.Framework;

namespace DanM.Core.Services.Controllers;

public abstract class EntityListControllerBase<TEntity, TData> : ListControllerBase<TData>
	where TEntity : class, IEntity, new()
	where TData : ListControllerData
{
	protected EntityListControllerBase(IDetailControllerServices services)
		: base(services)
	{
	}
}

public interface IEntityListControllerBase<TEntity, TData> : IListControllerBase<TData>
	where TEntity : class, IEntity, new()
	where TData : ListControllerData
{
}