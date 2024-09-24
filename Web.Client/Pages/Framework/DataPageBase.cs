using DanM.HrSystem.Contracts.ControlDatas;
using Microsoft.AspNetCore.Components.Forms;

namespace DanM.HrSystem.Web.Client.Pages.Framework;

public abstract class DataPageBase<TData> : PageBase
	where TData : IControllerData, new()
{
	public TData Data { get; private set; }
	protected EditContext conEditContext;

	protected override async Task OnPageInit()
	{
		await base.OnPageInit();

		this.Data = this.CreateControllerData();
		this.PrepareControllerData();
		conEditContext = new EditContext(this.Data);

		var response = await this.CallControllerRequest();
		this.Data = response;
		conEditContext = new EditContext(this.Data);
	}

	protected virtual TData CreateControllerData()
	{
		return new TData();
	}

	protected virtual void PrepareControllerData()
	{
	}

	protected abstract Task<TData> CallControllerRequest();
}
