using System.Security.Claims;
using DanM.Core.Contracts.Infrastructure.Security;
using DanM.HrSystem.DataLayer.Repositories.Security;
using DanM.HrSystem.Model.Security;
using DanM.Core.Services.Infrastructure.Security;

namespace DanM.HrSystem.Web.Server.Infrastructure.Security;

public class ApplicationAuthenticationService : IApplicationAuthenticationService
{
	private readonly IHttpContextAccessor _httpContextAccessor;

	private readonly Lazy<User> _userLazy;

	public ApplicationAuthenticationService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
	{
		_httpContextAccessor = httpContextAccessor;

		_userLazy = new Lazy<User>(() => userRepository.GetObject(GetCurrentUserId()));
	}

	public ClaimsPrincipal GetCurrentClaimsPrincipal()
	{
		return _httpContextAccessor.HttpContext.User;
	}

	public User GetCurrentUser() => _userLazy.Value;

	public int GetCurrentUserId()
	{
		var principal = GetCurrentClaimsPrincipal();
		Claim userIdClaim = principal.Claims.Single(claim => (claim.Type == ClaimConstants.UserIdClaim));
		return Int32.Parse(userIdClaim.Value);
	}
}
