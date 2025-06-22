namespace S.A.M.Helper.Resources;

public static class CultureHelper
{
    public static readonly string[] SupportedCultures = { "en", "ar", "fr", "es" };

    public static readonly Dictionary<string, string> CultureDisplayNames = new()
    {
        { "en", "English" },
        { "ar", "العربية" },
        { "fr", "Français" },
        { "es", "Español" }
    };

    public static readonly Dictionary<string, string> CultureFlags = new()
    {
        { "en", "🇺🇸" },
        { "ar", "🇸🇦" },
        { "fr", "🇫🇷" },
        { "es", "🇪🇸" }
    };

    public static bool IsValidCulture(string culture)
    {
        return SupportedCultures.Contains(culture);
    }

    public static bool IsRightToLeft(string culture)
    {
        return culture == "ar";
    }

    public static string GetCultureDisplayName(string culture)
    {
        return CultureDisplayNames.TryGetValue(culture, out var displayName) ? displayName : culture;
    }

    public static string GetCultureFlag(string culture)
    {
        return CultureFlags.TryGetValue(culture, out var flag) ? flag : "🌐";
    }
}