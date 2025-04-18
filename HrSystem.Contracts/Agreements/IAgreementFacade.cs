namespace DanM.HrSystem.Contracts.Agreements;

[ApiContract]
public interface IAgreementFacade
{
	Task<List<AgreementGridDto>> GetDtosAsync(CancellationToken cancellationToken = default);
}