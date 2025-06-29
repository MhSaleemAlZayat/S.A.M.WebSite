using S.A.M.Data.Entities;

namespace S.A.M.Data.Repositories.Languages;

public interface ILanguageRepository
{
    Task<IEnumerable<Language>> GetAllLanguagesAsync();
    Task<Language?> GetLanguageByIdAsync(byte id);
    Task<Language?> GetLanguageByCodeAsync(string code);
    Task<Language> AddLanguageAsync(Language language);
    Task<Language> UpdateLanguageAsync(Language language);
    Task<bool> DeleteLanguageAsync(byte id);

    Task<bool> ChangeDefaultLanguageAsync(byte id);
    Task<Language> ChangeLanguageActivationStatusAsync(byte id);
}