using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using S.A.M.Data;
using S.A.M.Data.Entities.AspIdentity;
using S.A.M.Helper.Services.AspIdentity.UserManager;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace S.A.M.Helper.ProgramHelper;

public static class IdentityConfigure
{
    public static void ConfigureIdentity(this WebApplicationBuilder builder)
    {
        // Configure Authentication with External Providers
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/ControlPanel/Account/Login"; // Redirect to login page
                options.LogoutPath = "/ControlPanel/Account/Logout";
                options.AccessDeniedPath = "/ControlPanel/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Session timeout
                options.SlidingExpiration = true; // Extend session on activity
                options.Cookie.HttpOnly = true; // Security measure
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            })
            // Google OAuth
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
                options.CallbackPath = "/signin-google";
                options.SaveTokens = true;
            })
            // Facebook OAuth
            .AddFacebook(options =>
            {
                options.AppId = builder.Configuration["Authentication:Facebook:AppId"];
                options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"];
                options.CallbackPath = "/signin-facebook";
                options.SaveTokens = true;
                options.Fields.Add("email");
                options.Fields.Add("name");
            })
            // X (Twitter) OAuth
            .AddTwitter(options =>
            {
                options.ConsumerKey = builder.Configuration["Authentication:Twitter:ConsumerKey"];
                options.ConsumerSecret = builder.Configuration["Authentication:Twitter:ConsumerSecret"];
                options.CallbackPath = "/signin-twitter";
                options.SaveTokens = true;
            })
            // LinkedIn OAuth
            .AddOAuth("LinkedIn", "LinkedIn", options =>
            {
                options.ClientId = builder.Configuration["Authentication:LinkedIn:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:LinkedIn:ClientSecret"];
                options.CallbackPath = "/signin-linkedin";
                options.AuthorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";
                options.TokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";
                options.UserInformationEndpoint = "https://api.linkedin.com/v2/people/~:(id,firstName,lastName,emailAddress)";
                options.SaveTokens = true;
                options.Scope.Add("r_liteprofile");
                options.Scope.Add("r_emailaddress");

                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "firstName");
                options.ClaimActions.MapJsonKey(ClaimTypes.Surname, "lastName");
                options.ClaimActions.MapJsonKey(ClaimTypes.Email, "emailAddress");

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                        response.EnsureSuccessStatusCode();

                        var json = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
                        context.RunClaimActions(json.RootElement);
                    }
                };
            });




        builder.Services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;

            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            options.User.RequireUniqueEmail = true;

            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
            options.Lockout.MaxFailedAccessAttempts = 3;

        })
        .AddEntityFrameworkStores<SAMDbContext>()
        .AddDefaultTokenProviders();

        builder.Services.AddScoped<UserManagerService>();

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.Redirect("/ControlPanel/Account/Login");
                return Task.CompletedTask;
            };

        });
        // Add Authorization services
        builder.Services.AddAuthorization(options =>
        {
            // Create a policy for the control panel area
            options.AddPolicy("ControlPanelAccess", policy =>
            {
                policy.RequireAuthenticatedUser();
                // Add additional requirements if needed, e.g.:
                // policy.RequireRole("Admin");
                // policy.RequireClaim("Permission", "ControlPanel");
            });
        });

    }
}
