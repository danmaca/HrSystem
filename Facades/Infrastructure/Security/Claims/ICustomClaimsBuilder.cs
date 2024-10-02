using System.Security.Claims;

namespace DanM.Core.Facades.Infrastructure.Security.Claims;

public interface ICustomClaimsBuilder
{
	Task<List<Claim>> GetCustomClaimsAsync(ClaimsPrincipal principal, CancellationToken cancellationToken = default);
}
