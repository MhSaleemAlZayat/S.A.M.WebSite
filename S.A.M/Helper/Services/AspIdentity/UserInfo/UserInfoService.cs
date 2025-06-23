using System.Security.Claims;

namespace S.A.M.Helper.Services.AspIdentity.UserInfo;

public class UserInfoService : IUserInfoService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserInfoService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserName
        => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unknown";

    public string UserEmail
        => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value ?? "unknown@sam.org";
}
