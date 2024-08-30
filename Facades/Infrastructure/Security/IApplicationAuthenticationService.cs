using System.Security.Claims;
using DanM.HrSystem.Model.Security;

namespace DanM.HrSystem.Services.Infrastructure.Security;

public interface IApplicationAuthenticationService
{
	ClaimsPrincipal GetCurrentClaimsPrincipal();
	User GetCurrentUser();
}
