using DanM.HrSystem.Contracts.ControlDatas;
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

	protected override void OnDataSet()
	{
		base.OnDataSet();

		this.Data.Setup.EntityId = this.Data.Setup.Navigation.Params.GetInt("Id");
	}

	protected abstract Task<TEntity> OnLoadEntityAsync();

	protected virtual TEntity OnCreateEntity()
	{
		return new TEntity();
	}

	protected override async Task OnLoadAsync()
	{
		await base.OnLoadAsync();

		this.Entity = await this.GetEntityAsync();
		this.BindProperties(BindingMode.UpdateForm);
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

public interface IDetailControllerBase<TData> : IControllerBase<TData>
	where TData : DetailControllerData
{
}