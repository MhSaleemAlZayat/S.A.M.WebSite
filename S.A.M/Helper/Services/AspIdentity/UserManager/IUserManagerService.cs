using Microsoft.AspNetCore.Identity;
using S.A.M.Data.Entities.AspIdentity;

namespace S.A.M.Helper.Services.AspIdentity.UserManager
{
    public interface IUserManagerService
    {
        Task<IdentityResult> Add(User userDTO, string password);

        Task<User> GetById(string userId);

        Task<List<User>> GetAll(bool active, bool includeUserRole, bool includeUserLogin, bool includeUserClaim, bool includeUserToken);

        Task<User> GetByEamil(string eamil);

        Task<List<User>> GetByIdList(List<string> userIds, bool active, bool includeUserRole, bool includeUserLogin, bool includeUserClaim, bool includeUserToken);

        UserManager<User> UserManager { get; }

        Task<List<UserClaim>> GetUserCalimsById(string userId);
        Task<List<UserClaim>> GetUserCalimsByUser(User user);
    }
}