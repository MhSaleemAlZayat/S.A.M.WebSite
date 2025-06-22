using Microsoft.AspNetCore.Identity;

namespace S.A.M.Helper.Services.AspIdentity.Role
{
    public interface IRoleManagerService
    {
        Task<IdentityResult> Add(Data.Entities.AspIdentity.Role roleDTO);


        Task<bool> Delete(string roleId, string userId);

        Task<List<Data.Entities.AspIdentity.Role>> GetAll();

        Task<Data.Entities.AspIdentity.Role> GetById(string roleId);
    }
}