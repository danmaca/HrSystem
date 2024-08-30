using DanM.HrSystem.Model.Security;

namespace DanM.HrSystem.DataLayer.Repositories.Security;

public partial interface IUserRepository
{
	Task<User> GetByIdentityProviderIdAsync(string identityProviderId, CancellationToken cancellationToken = default);
}
