using S.A.M.Helper.BackgroundQueue;
using S.A.M.Helper.Configuration;
using S.A.M.Helper.Email;
using S.A.M.Helper.Email.EmailSender;
using S.A.M.Helper.Services.AspIdentity.Role;
using S.A.M.Helper.Services.AspIdentity.UserInfo;
using S.A.M.Helper.Services.AspIdentity.UserManager;
using S.A.M.Helper.Services.AspIdentity.UserRole;
using S.A.M.Models.Configurations;

namespace S.A.M.Helper.ProgramHelper;

public static class ServiceConfigure
{
    internal static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApplicationConfigurationService>(builder.Configuration.GetSection("Default:ApplicationConfiguration"));
        //builder.Services.Configure<ImageUploadingConfiguration>(builder.Configuration.GetSection("Default:ImageUploadingConfiguration"));
        //builder.Services.Configure<ObjectStorageConfiguration>(builder.Configuration.GetSection("Default:ObjectStorageConfiguration"));
        builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("Default:EmailConfiguration"));
        builder.Services.Configure<AspIdentityDefault>(builder.Configuration.GetSection("Default:AspIdentity"));

        builder.Services.AddSingleton<IApplicationConfigurationService, ApplicationConfigurationService>();

        builder.Services.AddHostedService<QueuedHostedService>();
        builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();

        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IUserInfoService, UserInfoService>();

        builder.Services.AddScoped<IEmailSenderSerivce, EmailSenderSerivce>();
        builder.Services.AddScoped<IRoleManagerService, RoleManagerService>();
        builder.Services.AddScoped<IUserManagerService, UserManagerService>();
        builder.Services.AddScoped<IUserRoleService, UserRoleService>();
    }

}
