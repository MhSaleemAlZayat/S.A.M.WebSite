using Microsoft.EntityFrameworkCore;
using S.A.M.Data.Entities;
namespace S.A.M.Data.Repositories.Languages;

public class LanguageRepository : ILanguageRepository
{
    private readonly SAMDbContext _context;
    private readonly DbSet<Language> _language;
    private readonly ILogger<LanguageRepository> _logger;
    //private readonly IMapper _mapper;
    public LanguageRepository(SAMDbContext context, ILogger<LanguageRepository> logger)
    {
        _context = context;
        _language = context.Set<Language>();
        _logger = logger;
    }

    public async Task<IEnumerable<Language>> GetAllLanguagesAsync()
    {
        try
        {
            return await _language.Where(l => !l.IsDeleted).ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving languages");
            throw;
        }
    }

    public async Task<Language?> GetLanguageByIdAsync(byte id)
    {
        try
        {
            return await _language.FirstOrDefaultAsync(l => l.Id == id && !l.IsDeleted);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving language by ID");
            throw;
        }
    }

    public async Task<Language?> GetLanguageByCodeAsync(string code)
    {
        try
        {
            return await _language.FirstOrDefaultAsync(l => l.Code == code && !l.IsDeleted);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving language by code");
            throw;
        }
    }

    public async Task<Language> AddLanguageAsync(Language language)
    {
        try
        {
            await _language.AddAsync(language);
            await _context.SaveChangesAsync();
            return language;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding language");
            throw;
        }
    }

    public async Task<Language> UpdateLanguageAsync(Language language)
    {
        try
        {
            var existingLanguage = await _language.FindAsync(language.Id);

            if (existingLanguage == null || existingLanguage.IsDeleted)
            {
                _logger.LogWarning("Attempted to update a non-existing or deleted language with ID {Id}", language.Id);
                throw new KeyNotFoundException($"Language with ID {language.Id} not found or is deleted.");
            }

            language.UpdatedAt = DateTime.UtcNow;
            _language.Update(language);
            await _context.SaveChangesAsync();
            return language;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating language");
            throw;
        }
    }

    public async Task<bool> DeleteLanguageAsync(byte id)
    {
        try
        {
            var language = await _language.FindAsync(id);
            if (language == null || language.IsDeleted)
            {
                _logger.LogWarning("Attempted to delete a non-existing or already deleted language with ID {Id}", id);
                return false;
            }

            language.IsDeleted = true;

            language.UpdatedAt = DateTime.UtcNow;

            _language.Update(language);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting language");
            throw;
        }
    }

}
