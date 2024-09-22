using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Contracts.Framework.Controllers;

public interface IDetailControllerBase<TData> : IControllerBase<TData>
	where TData : DetailControllerData
{
}