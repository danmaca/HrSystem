using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

public interface IControllerBase<TData>
	where TData : IControllerData
{
	Task<TData> GetDetailDataAsync(TData data, CancellationToken cancellationToken = default);
}