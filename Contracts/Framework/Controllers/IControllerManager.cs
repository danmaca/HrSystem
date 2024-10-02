using DanM.Core.Contracts.ControlDatas;

namespace DanM.Core.Contracts.Framework.Controllers;

[ApiContract]
public interface IControllerManager
{
	Task<ControllerCallResponse> GetControllerDataAsync(ControllerCallRequest request, CancellationToken cancellationToken = default);
}