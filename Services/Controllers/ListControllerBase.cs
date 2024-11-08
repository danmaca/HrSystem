using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Binders;

namespace DanM.Core.Services.Controllers;

public abstract class ListControllerBase<TData> : ControllerBase<TData>, IListControllerBase<TData>, IListControllerBase
	where TData : ListControllerData
{
	public IListControllerServices Services { get; }

	public IStandardBinders Binders => this.Services.Binders;

	protected ListControllerBase(IListControllerServices services)
	{
		this.Services = services;
	}

	protected override async Task OnLoadAsync()
	{
		await base.OnLoadAsync();

		if (this.Data.Setup.IsPostback == false)
		{
			await this.UpdateFormAsync();
		}
	}

	protected virtual Task UpdateFormAsync()
	{
		this.BindProperties(BindingMode.UpdateForm);
		return Task.CompletedTask;
	}

	protected virtual Task UpdateEntityAsync()
	{
		this.BindProperties(BindingMode.UpdateEntity);
		return Task.CompletedTask;
	}

	private void BindProperties(BindingMode bindingMode)
	{
		var ctx = new BindingContext()
		{
			Mode = bindingMode,
		};

		this.OnBindingProperties(ctx);
	}

	protected virtual void OnBindingProperties(BindingContext ctx)
	{
	}
}

public interface IListControllerBase<TData> : IControllerBase<TData>
	where TData : ListControllerData
{
}

public interface IListControllerBase
{
}