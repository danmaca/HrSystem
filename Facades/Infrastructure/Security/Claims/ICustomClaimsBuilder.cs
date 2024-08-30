using System.Security.Claims;

namespace DanM.HrSystem.Facades.Infrastructure.Security.Claims;

public interface ICustomClaimsBuilder
{
	Task<List<Claim>> GetCustomClaimsAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
}
