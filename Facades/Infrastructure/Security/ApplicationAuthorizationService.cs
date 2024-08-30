using System.Security.Claims;
using Havit.Extensions.DependencyInjection.Abstractions;
using DanM.HrSystem.Primitives.Security;

namespace DanM.HrSystem.Services.Infrastructure.Security;

[Service(Profile = ServiceProfiles.WebServer)]
public class ApplicationAuthorizationService : IApplicationAuthorizationService
{
	private readonly IApplicationAuthenticationService _applicationAuthenticationService;

	public ApplicationAuthorizationService(IApplicationAuthenticationService applicationAuthenticationService)
	{
		_applicationAuthenticationService = applicationAuthenticationService;
	}

	public IEnumerable<RoleEntry> GetCurrentUserRoles()
	{
		return _applicationAuthenticationService.GetCurrentClaimsPrincipal().FindAll(ClaimTypes.Role).Select(c => Enum.Parse<RoleEntry>(c.Value));
	}

	public bool IsCurrentUserInRole(RoleEntry role)
	{
		return _applicationAuthenticationService.GetCurrentClaimsPrincipal().IsInRole(role.ToString());
	}
}
