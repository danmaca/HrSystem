using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Services.Binders;
using DanM.Core.Services.Workflows;
using DanM.HrSystem.Model.Framework;

namespace DanM.Core.Services.Controllers;

public abstract class DetailControllerBase<TEntity, TData> : ControllerBase<TData>, IDetailControllerBase<TData>, IDetailControllerBase
	where TEntity : class, IEntity, new()
	where TData : DetailControllerData
{
	public IDetailControllerServices Services { get; }

	public TEntity Entity { get; set; }
	public IStandardBinders Binders => this.Services.Binders;

	protected DetailControllerBase(IDetailControllerServices services)
	{
		this.Services = services;
	}

	protected override void OnControllerDataSet()
	{
		base.OnControllerDataSet();

		this.Data.Setup.EntityId = this.Data.Setup.Navigation.Params.GetInt("Id");
	}

	protected abstract Task<TEntity> OnLoadEntityAsync();

	protected virtual TEntity OnCreateEntity()
	{
		return new TEntity();
	}

	protected override async Task OnInitAsync()
	{
		await base.OnInitAsync();

		this.Entity = await this.GetEntityAsync();
		await this.Binders.WorkflowBinder.TryRunTransition(Data.conActionButtonizer, this.RunWorkflowTransition);
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
		var ctx = new BindingContext()
		{
			Mode = bindingMode,
		};
		ctx.BindingEntity = this.Entity;
		ctx.WorkflowRequest = new WorkflowRequest();
		ctx.WorkflowRequest.WorkflowEntity = this.Entity;
		ctx.WorkflowRequest.BindingEntity = this.Entity;
		ctx.Workflow = this.Services.WorkflowManager.ResolveWorkflow(ctx.WorkflowRequest);

		this.Binders.WorkflowBinder.Bind(ctx, Data.conActionButtonizer);

		this.OnBindingProperties(ctx);
	}

	protected virtual void OnBindingProperties(BindingContext ctx)
	{
	}

	public async Task PersistDetailDtoAsync()
	{
		await this.UpdateEntityAsync();

		if (this.Data.Setup.EntityId != null)
			this.Services.UnitOfWork.AddForUpdate(this.Entity);
		else
			this.Services.UnitOfWork.AddForInsert(this.Entity);

		await this.Services.UnitOfWork.CommitAsync();
	}

	public async Task RunWorkflowTransition(string transitionKey)
	{
		await this.UpdateEntityAsync();

		var wfRequest = new WorkflowRequest();
		wfRequest.Dialog = Data.conActionButtonizer.CurrentDialog;
		wfRequest.WorkflowEntity = this.Entity;
		wfRequest.BindingEntity = this.Entity;

		wfRequest.TransitionKey = transitionKey;
		var workflow = this.Services.WorkflowManager.ResolveWorkflow(wfRequest);

		var runResult = workflow.RunTransition(wfRequest);

		if (runResult.Result.IsValid)
		{
			if (runResult.ChangeToDialog != null)
				Data.conActionButtonizer.CurrentDialog = runResult.ChangeToDialog;

			await this.UpdateFormAsync();
		}
	}
}

public interface IDetailControllerBase<TData> : IControllerBase<TData>
	where TData : DetailControllerData
{
}

public interface IDetailControllerBase
{
	Task RunWorkflowTransition(string transitionKey);
}