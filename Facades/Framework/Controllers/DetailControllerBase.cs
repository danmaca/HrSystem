using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Model.Framework;

namespace DanM.HrSystem.Facades.Framework.Controllers;

public abstract class DetailControllerBase<TEntity, TData> : ControllerBase<TData>, IDetailControllerBase<TData>
	where TEntity : IEntity
	where TData : DetailControllerData
{
	public TEntity Entity { get; set; }

	public async Task<TData> GetDetailDataAsync(TData data, CancellationToken cancellationToken = default)
	{
		this.Data = data;

		this.Entity = await this.OnCreateEntityAsync();
		this.OnBindingProperties();
		return data;
	}

	protected abstract Task<TEntity> OnCreateEntityAsync();

	protected virtual void OnBindingProperties()
	{
	}
}