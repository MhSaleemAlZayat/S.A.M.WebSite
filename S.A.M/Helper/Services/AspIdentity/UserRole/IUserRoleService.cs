namespace S.A.M.Helper.Services.AspIdentity.UserRole;

public interface IUserRoleService
{
    public Task AddToRoleAsync(string userId, string roleId, string createdBy = null);
}
