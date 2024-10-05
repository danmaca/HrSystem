using DanM.Core.Contracts.ControlDatas;
using DanM.Core.Contracts.Controllers;
using DanM.HrSystem.Primitives.Utils;

namespace DanM.Core.Facades.Framework.Controllers;

public abstract class ControllerBase<TData> : IControllerBase<TData>
	where TData : IControllerData
{
	public TData Data { get; protected set; }

	Task<ControllerCallResponse> IControllerBase.ProcessDataAsync(ControllerCallRequest requestInfo, CancellationToken cancellationToken) => this.OnProcessDataAsync(requestInfo, cancellationToken);

	protected async Task<ControllerCallResponse> OnProcessDataAsync(ControllerCallRequest requestInfo, CancellationToken cancellationToken)
	{
		IControllerData contentData = requestInfo.ContentData;

		if (requestInfo.IsPostback == false)
		{
			Type controllerDataType = TypeResolver.GetType(requestInfo.ContentDataTypeName);
			contentData = (IControllerData)Activator.CreateInstance(controllerDataType);
			contentData.Setup.Navigation = requestInfo.Navigation;
			requestInfo.Navigation = null;
		}

		contentData.Setup.IsPostback = requestInfo.IsPostback;

		this.Data = (TData)contentData;

		await this.OnProcessControllerAsync();

		var response = new ControllerCallResponse();
		response.ContentData = contentData;
		return response;
	}

	protected async Task OnProcessControllerAsync()
	{
		this.OnControllerDataSet();
		await this.OnInitAsync();
		await this.OnLoadAsync();
	}

	protected virtual void OnControllerDataSet()
	{
	}

	protected virtual Task OnInitAsync()
	{
		return Task.CompletedTask;
	}

	protected virtual Task OnLoadAsync()
	{
		return Task.CompletedTask;
	}
}

public interface IControllerBase<TData> : IControllerBase
	where TData : IControllerData
{
}

public interface IControllerBase
{
	Task<ControllerCallResponse> ProcessDataAsync(ControllerCallRequest requestInfo, CancellationToken cancellationToken = default);
}