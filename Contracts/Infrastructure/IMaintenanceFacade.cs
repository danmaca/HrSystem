using Havit.ComponentModel;

namespace DanM.HrSystem.Contracts.Infrastructure;

[ApiContract]
public interface IMaintenanceFacade
{
	Task ClearCacheAsync(CancellationToken cancellationToken = default);
}
