using Havit.ComponentModel;

namespace DanM.Core.Contracts.Infrastructure;

[ApiContract]
public interface IMaintenanceFacade
{
	Task ClearCacheAsync(CancellationToken cancellationToken = default);
}
