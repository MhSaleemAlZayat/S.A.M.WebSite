using Microsoft.EntityFrameworkCore;
using S.A.M.Data;
using S.A.M.Helper.Configuration;
using S.A.M.Helper.Services.AspIdentity.Role;
using S.A.M.Helper.Services.AspIdentity.UserManager;
using S.A.M.Helper.Services.AspIdentity.UserRole;
using S.A.M.Models.Configurations;

namespace S.A.M.Helper.ProgramHelper;

internal static class DatabaseConfigure
{
    internal static void ConfigureDatabase(this WebApplicationBuilder builder)
    {

        // Configure EF Core with a connection string (replace with your actual connection string)
        //builder.Services.AddDbContext<SAMDbContext>(options =>
        //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        //builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        //    .AddEntityFrameworkStores<SAMDbContext>()
        //    .AddDefaultTokenProviders();

        builder.Services.AddDbContext<SAMDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        );
    }

    internal static void RunDatabaseMigration(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var projectDbContext = scope.ServiceProvider.GetRequiredService<SAMDbContext>();
            projectDbContext.Database.Migrate();

        }
    }

    internal static void AddApplicationRolesAndUsers(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var config = scope.ServiceProvider.GetRequiredService<IApplicationConfigurationService>();
            //var dbContext = scope.ServiceProvider.GetRequiredService<ProjectDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<IRoleManagerService>();
            var userManager = scope.ServiceProvider.GetRequiredService<IUserManagerService>();
            var userRoleService = scope.ServiceProvider.GetRequiredService<IUserRoleService>();


            //Log.Debug("Starting adding roles...");

            Data.Entities.AspIdentity.Role? adminRole = AddRole(config, roleManager, config.AspIdentity.AdminRole);
            Data.Entities.AspIdentity.Role? systemWonerRole = AddRole(config, roleManager, config.AspIdentity.SystemWonerRole);
            Data.Entities.AspIdentity.Role? contentManagerRole = AddRole(config, roleManager, config.AspIdentity.ContentManagerRole);
            Data.Entities.AspIdentity.Role? contentCreatorRole = AddRole(config, roleManager, config.AspIdentity.ContentCreatorRole);
            Data.Entities.AspIdentity.Role? contentDrafterRole = AddRole(config, roleManager, config.AspIdentity.ContentDrafterRole);
            Data.Entities.AspIdentity.Role? visitorCreatorRole = AddRole(config, roleManager, config.AspIdentity.VisitorRole);



            var user = userManager.GetById(config.AspIdentity.AdminUser.Id).Result;
            if (user is null || string.IsNullOrEmpty((user is not null ? user.Id : string.Empty)))
            {
                user = new Data.Entities.AspIdentity.User
                {
                    Id = config.AspIdentity.AdminUser.Id,
                    Email = config.AspIdentity.AdminUser.Email,
                    UserName = config.AspIdentity.AdminUser.UserName,
                    System = true,
                    CreatedBy = "System"
                };
                var userResult = userManager.Add(user, config.AspIdentity.AdminUser.Password).Result;
            }

            var added = userManager.UserManager.IsInRoleAsync(user, config.AspIdentity.AdminRole.Name).Result;

            if (!added)
                userRoleService.AddToRoleAsync(user.Id, config.AspIdentity.AdminRole.Id).GetAwaiter().GetResult();

        }
    }

    private static Data.Entities.AspIdentity.Role? AddRole(IApplicationConfigurationService config, IRoleManagerService roleManager, DefaultRole role)
    {
        var dbrole = roleManager.GetById(role.Id).Result;
        if (dbrole is null || string.IsNullOrEmpty((dbrole is not null ? dbrole.Id : string.Empty)))
        {
            dbrole = new Data.Entities.AspIdentity.Role
            {
                Id = role.Id,
                Name = role.Name,
                System = true,
                Preview = role.Preview,
                CreatedBy = "System"
            };
            roleManager.Add(dbrole).GetAwaiter().GetResult();
        }

        return dbrole;
    }
}
