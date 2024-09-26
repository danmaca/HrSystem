using DanM.HrSystem.Contracts.ControlDatas;
using DanM.HrSystem.Contracts.Framework.Controllers;
using DanM.HrSystem.Web.Client.Framework.Communication;
using Microsoft.AspNetCore.Components.Forms;

namespace DanM.HrSystem.Web.Client.Framework;

public abstract class DataPageBase<TData> : PageBase
	where TData : IControllerData, new()
{
	public TData Data { get; private set; }

	[Inject] public IServerCommunicator _serverCommunicator { get; set; }

	protected override async Task OnPageInit()
	{
		await base.OnPageInit();

		var response = await this.CallControllerRequest();
		this.Data = (TData)response.ContentData;
	}

	protected virtual void InitialControllerRequest(ControllerCallRequest request)
	{
	}

	protected virtual void PrepareControllerRequest(ControllerCallRequest request)
	{
	}

	protected async Task<ControllerCallResponse> CallControllerRequest()
	{
		var request = new ControllerCallRequest();
		request.ContentData = this.Data;

		if (this.Data == null)
			this.InitialControllerRequest(request);
		else
			this.PrepareControllerRequest(request);

		var response = await _serverCommunicator.CallController(request);
		return response;
	}
}
