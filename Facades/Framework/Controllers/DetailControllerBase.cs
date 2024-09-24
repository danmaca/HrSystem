using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Model.Framework;
using DanM.HrSystem.Services.Framework.Binders;

namespace DanM.HrSystem.Facades.Framework.Controllers;

public abstract class DetailControllerBase<TEntity, TData> : ControllerBase<TData>, IDetailControllerBase<TData>
	where TEntity : IEntity, new()
	where TData : DetailControllerData
{
	private readonly IDetailControllerServices _services;

	public TEntity Entity { get; set; }
	public IStandardBinders Binders { get; }

	protected DetailControllerBase(IDetailControllerServices services)
	{
		_services = services;
		this.Binders = services.Binders;
	}

	protected abstract Task<TEntity> OnLoadEntityAsync();

	protected virtual TEntity OnCreateEntity()
	{
		return new TEntity();
	}

	public async Task<TData> GetDetailDataAsync(TData data, CancellationToken cancellationToken = default)
	{
		this.Data = data;

		this.Entity = await this.GetEntityAsync();
		this.BindProperties(BindingMode.UpdateForm);
		return data;
	}

	protected async Task<TEntity> GetEntityAsync()
	{
		TEntity entity;
		if (this.Data.Setup.EntityId != null)
			entity = await this.OnLoadEntityAsync();
		else
			entity = this.OnCreateEntity();
		return entity;
	}

	private void BindProperties(BindingMode bindingMode)
	{
		var ctx = new BindingContext();
		ctx.Mode = bindingMode;
		ctx.BindingEntity = this.Entity;

		this.OnBindingProperties(ctx);
	}

	protected virtual void OnBindingProperties(BindingContext ctx)
	{
	}
}