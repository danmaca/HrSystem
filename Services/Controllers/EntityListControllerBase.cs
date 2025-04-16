using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Filtering;
using DanM.Core.Model.Framework;

namespace DanM.Core.Services.Controllers;

public abstract class EntityListControllerBase<TEntity, TFilter, TData> : ListControllerBase<TFilter, TData>
	where TEntity : class, IEntity, new()
	where TFilter : class, IFilterBase, new()
	where TData : ListControllerData
{
	protected EntityListControllerBase(IListControllerServices services)
		: base(services)
	{
	}
}

public interface IEntityListControllerBase<TEntity, TFilter, TData> : IListControllerBase<TFilter, TData>
	where TEntity : class, IEntity, new()
	where TFilter : class, IFilterBase, new()
	where TData : ListControllerData
{
}