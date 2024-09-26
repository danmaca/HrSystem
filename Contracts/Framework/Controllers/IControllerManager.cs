using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

[ApiContract]
public interface IControllerManager
{
	Task<ControllerCallResponse> GetControllerDataAsync(ControllerCallRequest request, CancellationToken cancellationToken = default);
}