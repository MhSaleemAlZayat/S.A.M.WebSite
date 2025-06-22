using Microsoft.Extensions.Localization;
using S.A.M.Helper.Resources;

namespace S.A.M.Services;

public class LocalizationService : ILocalizationService
{
    private readonly IStringLocalizer<SharedResources> _localizer;

    public LocalizationService(IStringLocalizer<SharedResources> localizer)
    {
        _localizer = localizer;
    }

    public string GetLocalizedString(string key, params object[] arguments)
    {
        var localizedString = _localizer[key, arguments];
        return localizedString.ResourceNotFound ? key : localizedString.Value;
    }

    public string GetLocalizedString(string key, string culture, params object[] arguments)
    {
        // This would require additional implementation to get localized string for specific culture
        // For now, return the current culture's localization
        return GetLocalizedString(key, arguments);
    }

    public IEnumerable<KeyValuePair<string, string>> GetAllStrings(bool includeParentCultures = true)
    {
        return _localizer.GetAllStrings(includeParentCultures)
                       .Select(x => new KeyValuePair<string, string>(x.Name, x.Value));
    }

    public bool IsKeyExists(string key)
    {
        return !_localizer[key].ResourceNotFound;
    }
}