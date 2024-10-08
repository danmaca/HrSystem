﻿using System.Linq.Expressions;
using Havit.Data.EntityFrameworkCore.Patterns.Repositories;
using DanM.HrSystem.Model.Security;
using Microsoft.EntityFrameworkCore;

namespace DanM.HrSystem.DataLayer.Repositories.Security;

public partial class UserDbRepository : IUserRepository
{
	public async Task<User> GetByIdentityProviderIdAsync(string identityProviderId, CancellationToken cancellationToken = default)
	{
		Contract.Requires<ArgumentException>(!String.IsNullOrWhiteSpace(identityProviderId));

		return await Data.Include(GetLoadReferences).FirstOrDefaultAsync(u => u.IdentityProviderExternalId == identityProviderId, cancellationToken);
	}

	protected override IEnumerable<Expression<Func<User, object>>> GetLoadReferences()
	{
		yield return (User u) => u.UserRoles;
	}
}
