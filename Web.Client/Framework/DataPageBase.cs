using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Controllers;
using DanM.Core.Web.Client.Framework.Communication;

namespace DanM.Core.Web.Client.Framework;

public abstract class DataPageBase<TData> : PageBase, IDataPageBase
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
		request.ContentDataTypeName = typeof(TData).FullName;
	}

	protected virtual void PrepareControllerRequest(ControllerCallRequest request)
	{
	}

	public async Task DoPageDataPostback()
	{
		var response = await this.CallControllerRequest();
		this.Data = (TData)response.ContentData;
		this.StateHasChanged();
	}

	protected async Task<ControllerCallResponse> CallControllerRequest()
	{
		var request = new ControllerCallRequest();
		request.ContentData = this.Data;

		if (this.Data == null)
		{
			this.InitialControllerRequest(request);
			request.IsPostback = false;
		}
		else
		{
			this.PrepareControllerRequest(request);
			request.IsPostback = true;
		}

		var response = await _serverCommunicator.CallController(request);
		return response;
	}
}

public interface IDataPageBase
{
	Task DoPageDataPostback();
}