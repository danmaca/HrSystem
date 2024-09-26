namespace DanM.HrSystem.Contracts.Framework.Communication;

[ApiContract]
public interface IClientServerCommunicator
{
	Task<Dto<string>> CallControllerSerialized(Dto<string> jsonRequest, CancellationToken cancellationToken = default);
}