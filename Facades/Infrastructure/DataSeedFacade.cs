﻿using Havit;
using Havit.Data.Patterns.DataSeeds;
using Havit.Data.Patterns.DataSeeds.Profiles;
using Havit.Extensions.DependencyInjection.Abstractions;
using DanM.Core.Contracts;
using DanM.Core.Contracts.Infrastructure;
using DanM.HrSystem.DataLayer.Seeds.Core;
using DanM.HrSystem.Model.Security;
using DanM.HrSystem.Primitives.Security;
using Havit.Services.Caching;
using Microsoft.AspNetCore.Authorization;

namespace DanM.Core.Facades.Infrastructure;

[Service]
[Authorize(Roles = nameof(RoleEntry.SystemAdministrator))]

public class DataSeedFacade : IDataSeedFacade
{
	private readonly IDataSeedRunner _dataSeedRunner;
	private readonly ICacheService _cacheService;

	public DataSeedFacade(
		IDataSeedRunner dataSeedRunner,
		ICacheService cacheService)
	{
		_dataSeedRunner = dataSeedRunner;
		_cacheService = cacheService;
	}

	/// <summary>
	/// Executes seed for the selected profile.
	/// </summary>
	public async Task SeedDataProfileAsync(Dto<string> profileName, CancellationToken cancellationToken = default)
	{
		// applicationAuthorizationService.VerifyCurrentUserAuthorization(Operations.SystemAdministration); // TODO alternative authorization approach

		Type type = GetProfileTypes().FirstOrDefault(item => string.Equals(item.Name, profileName.Value, StringComparison.InvariantCultureIgnoreCase));

		if (type == null)
		{
			throw new OperationFailedException($"DataSeedProfile {profileName.Value} not found.");
		}

		// Individual seeds do not invalidate cache. If there are any cached entries (incl. empty-GetAll),
		// they get seeded and another seed asks for GetAll(), the newly seeded entities are not included.
		_cacheService.Clear();

		await _dataSeedRunner.SeedDataAsync(type, forceRun: true, cancellationToken);

		_cacheService.Clear();
	}

	/// <summary>
	/// Returns list of available data seed profiles (names are ready for use as parameter to <see cref="SeedDataProfileAsync"/> method).
	/// </summary>
	public Task<List<string>> GetDataSeedProfilesAsync(CancellationToken cancellationToken = default)
	{
		return Task.FromResult(GetProfileTypes()
						.Select(t => t.Name)
						.ToList()
		);
	}

	private static IEnumerable<Type> GetProfileTypes()
	{
		return typeof(CoreProfile).Assembly.GetTypes()
			.Where(t => t.GetInterfaces().Contains(typeof(IDataSeedProfile)));
	}
}
