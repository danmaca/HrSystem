using Havit.ComponentModel;

namespace DanM.HrSystem.Contracts.Infrastructure;

[ApiContract]
public interface IDataSeedFacade
{
	Task SeedDataProfileAsync(Dto<string> profileName, CancellationToken cancellationToken = default);

	Task<List<string>> GetDataSeedProfilesAsync(CancellationToken cancellationToken = default);
}
