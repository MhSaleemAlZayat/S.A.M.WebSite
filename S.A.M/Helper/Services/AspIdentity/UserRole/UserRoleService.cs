using S.A.M.Data;

namespace S.A.M.Helper.Services.AspIdentity.UserRole;

public class UserRoleService : IUserRoleService
{
    //private readonly UserManager<User> _userManager;
    //private readonly RoleManager<Role> _roleManager;
    private readonly SAMDbContext _context;
    public UserRoleService(SAMDbContext context)
    {
        _context = context;
        //UserManager<User> userManager, RoleManager< Role > roleManager
        //_userManager = userManager;
        //_roleManager = roleManager;
    }
    public async Task AddToRoleAsync(string userId, string roleId, string createdBy)
    {
        var userRole = new S.A.M.Data.Entities.AspIdentity.UserRole
        {
            UserId = userId,
            RoleId = roleId,
            CreatedBy = createdBy ?? "System",
            Active = true,
            IsDeleted = false,
            Preview = true,
            System = false
        };

        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync();

        //var user = await _userManager.FindByIdAsync(userId);
        //if (user == null)
        //{
        //    throw new ArgumentException("User not found.", nameof(userId));
        //}
        //var role = await _roleManager.FindByIdAsync(roleId);
        //if (role == null)
        //{
        //    throw new ArgumentException("Role not found.", nameof(roleId));
        //}
        //var result = await _userManager.AddToRoleAsync(user, role.Name);
        //if (!result.Succeeded)
        //{
        //    throw new InvalidOperationException("Failed to add user to role.");
        //}
    }
}
