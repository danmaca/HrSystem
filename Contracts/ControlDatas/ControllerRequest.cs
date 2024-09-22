namespace DanM.HrSystem.Contracts.ControlDatas;

public class ControllerRequest<TRequest, TDto> : IControllerRequest
	where TRequest : IControllerRequest
	where TDto : ControllerData, new()
{
}

public interface IControllerRequest
{
}