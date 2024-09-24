using DanM.HrSystem.Contracts.ControlDatas;

namespace DanM.HrSystem.Facades.Framework.Controllers;

public abstract class ControllerBase<TData> : IControllerBase<TData>
	where TData : IControllerData
{
	public TData Data { get; protected set; }
}


public interface IControllerBase<TData>
{
}