using Havit.Extensions.DependencyInjection.Abstractions;
using DanM.Core.Contracts.Infrastructure;
using DanM.HrSystem.Model.Security;
using DanM.HrSystem.Primitives.Security;
using Havit.Services.Caching;
using Microsoft.AspNetCore.Authorization;

namespace DanM.Core.Facades.Infrastructure;

[Service]
[Authorize(Roles = nameof(RoleEntry.SystemAdministrator))]
public class MaintenanceFacade : IMaintenanceFacade
{
	private readonly ICacheService _cacheService;

	public MaintenanceFacade(ICacheService cacheService)
	{
		_cacheService = cacheService;
	}

	public Task ClearCacheAsync(CancellationToken cancellationToken = default)
	{
		_cacheService.Clear();

		return Task.CompletedTask;
	}
}
