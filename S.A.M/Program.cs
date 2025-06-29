using Microsoft.AspNetCore.Mvc.Razor;
using S.A.M.Helper.ProgramHelper;
using S.A.M.Helper.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServices();

builder.ConfigureDatabase();

builder.ConfigureIdentity();

builder.Services.AddControllersWithViews();

builder.ConfigureLocalization();

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization(options =>
    {
        // Use shared resources for data annotations
        options.DataAnnotationLocalizerProvider = (type, factory) =>
            factory.Create(typeof(SharedResources));
    })
    .AddRazorRuntimeCompilation();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.RunDatabaseMigration();
app.AddApplicationRolesAndUsers();

app.UseHttpsRedirection();
app.UseRouting();

app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();

//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture("en"),
//    SupportedCultures = supportedCultures,
//    SupportedUICultures = supportedCultures,
//    RequestCultureProviders = new List<IRequestCultureProvider>
//    {
//        new CookieRequestCultureProvider(),
//        new AcceptLanguageHeaderRequestCultureProvider()
//    }
//});

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "ControlPanel",
//    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}")
//    .RequireAuthorization("ControlPanelAccess");

app.MapAreaControllerRoute(
    name: "mycontrolpanel",
    areaName: "ControlPanel",
    pattern: "ControlPanel/{controller=Dashboard}/{action=Index}/{id?}");
//.RequireAuthorization("ControlPanelAccess"); // Require authentication for all control panel routes


app.Run();
