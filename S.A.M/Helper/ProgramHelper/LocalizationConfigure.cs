using Microsoft.AspNetCore.Localization;
using S.A.M.Services;
using System.Globalization;

namespace S.A.M.Helper.ProgramHelper;

public static class LocalizationConfigure
{
    public static void ConfigureLocalization(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        // Register localization service
        builder.Services.AddScoped<ILocalizationService, LocalizationService>();

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("ar"),
                new CultureInfo("fr"),
                new CultureInfo("es")
            };

            options.DefaultRequestCulture = new RequestCulture("ar");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            // Culture detection providers (in order of priority)
            options.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider(),
                new AcceptLanguageHeaderRequestCultureProvider()
            };
        });

    }
}
