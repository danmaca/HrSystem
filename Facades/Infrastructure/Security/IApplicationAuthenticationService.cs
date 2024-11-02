using System.Security.Claims;
using DanM.HrSystem.Model.Security;

namespace DanM.Core.Services.Infrastructure.Security;

public interface IApplicationAuthenticationService
{
	ClaimsPrincipal GetCurrentClaimsPrincipal();
	User GetCurrentUser();
}
