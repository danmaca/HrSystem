using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

[ApiContract]
public interface IControllerManager
{
	Task<ControllerManagerResponse> GetControllerDataAsync(ControllerManagerRequest request, CancellationToken cancellationToken = default);
}