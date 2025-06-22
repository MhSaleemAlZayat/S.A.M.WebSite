namespace S.A.M.Services;

public interface ILocalizationService
{
    string GetLocalizedString(string key, params object[] arguments);
    string GetLocalizedString(string key, string culture, params object[] arguments);
    IEnumerable<KeyValuePair<string, string>> GetAllStrings(bool includeParentCultures = true);
    bool IsKeyExists(string key);
}