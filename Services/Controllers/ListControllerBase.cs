using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Filtering;
using DanM.Core.Services.Binders;

namespace DanM.Core.Services.Controllers;

public abstract class ListControllerBase<TFilter, TData> : ControllerBase<TData>, IListControllerBase<TFilter, TData>
	where TFilter : class, IFilterBase, new()
	where TData : ListControllerData
{
	public IListControllerServices Services { get; }

	public IStandardBinders Binders => this.Services.Binders;
	private TFilter _filter;
	public TFilter Filter
	{
		get
		{
			if (_filter == null)
				_filter = new TFilter();
			return _filter;
		}
	}

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
			this.OnFillMainGrid();
		}
		else
		{
			if (Data.pnlMainFilter.IsFilteringRequested)
			{
				await this.UpdateEntityAsync();
				Data.pnlMainFilter.IsFilteringRequested = false;
				this.OnFillMainGrid();
			}
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
		var ctx = new ListBindingContext()
		{
			Mode = bindingMode,
			BindingEntity = this.Filter,
		};

		this.OnBindingProperties(ctx);
	}

	protected virtual void OnBindingProperties(ListBindingContext ctx)
	{
	}

	protected abstract void OnFillMainGrid();
}

public interface IListControllerBase<TFilter, TData> : IControllerBase<TData>, IListControllerBase
	where TFilter : class, IFilterBase, new()
	where TData : ListControllerData
{
}

public interface IListControllerBase
{
}