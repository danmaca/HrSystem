namespace DanM.HrSystem.Contracts.Agreements;

[ApiContract]
public interface IAgreementFacade
{
	Task<List<AgreementGridDto>> GetItemsAsync(CancellationToken cancellationToken = default);
}