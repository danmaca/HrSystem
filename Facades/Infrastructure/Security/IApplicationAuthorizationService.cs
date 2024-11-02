using DanM.HrSystem.Primitives.Security;

namespace DanM.Core.Services.Infrastructure.Security;

public interface IApplicationAuthorizationService
{
	IEnumerable<RoleEntry> GetCurrentUserRoles();

	bool IsCurrentUserInRole(RoleEntry role);
}
