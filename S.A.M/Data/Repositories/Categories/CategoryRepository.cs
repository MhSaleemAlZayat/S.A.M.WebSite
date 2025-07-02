using Microsoft.EntityFrameworkCore;
using S.A.M.Data.Entities;

namespace S.A.M.Data.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly SAMDbContext _context;
    private readonly DbSet<Category> _categories;
    private readonly ILogger<CategoryRepository> _logger;
    private IEnumerable<object> _language;

    public CategoryRepository(SAMDbContext context, ILogger<CategoryRepository> logger)
    {
        _context = context;
        _categories = context.Set<Category>();
        _logger = logger;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        try
        {
            return await _categories
                .Include(c => c.Translations)
                .Include(c => c.Parent)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving categories");
            throw;
        }
    }

    public async Task<Category?> GetCategoryByIdAsync(short id)
    {
        try
        {
            return await _categories
                .Include(c => c.Translations)
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving category by ID");
            throw;
        }
    }

    public async Task<Category?> GetCategoryByNameAsync(string name)
    {
        try
        {
            return await _categories
                .Include(c => c.Translations)
                .FirstOrDefaultAsync(c => !c.IsDeleted);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving category by name");
            throw;
        }
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        try
        {
            await _categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding category");
            throw;
        }
    }

    public async Task<Category> UpdateCategoryAsync(Category category)
    {
        try
        {
            var existingCategory = await _categories.FindAsync(category.Id);

            if (existingCategory == null || existingCategory.IsDeleted)
            {
                _logger.LogWarning("Attempted to update a non-existing or deleted language with ID {Id}", category.Id);
                throw new KeyNotFoundException($"Language with ID {category.Id} not found or is deleted.");
            }

            category.UpdatedAt = DateTime.UtcNow;

            _categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating category");
            throw;
        }
    }

    public async Task<bool> DeleteCategoryAsync(short id)
    {
        try
        {
            var category = await _categories.FindAsync(id);
            if (category == null || category.IsDeleted)
            {
                _logger.LogWarning("Attempted to delete a non-existing or deleted category with ID {Id}", id);
                return false;
            }
            category.IsDeleted = true;
            category.UpdatedAt = DateTime.UtcNow;
            _categories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting category");
            throw;
        }
    }

    public async Task<Category> ChangeCategoryActivationStatusAsync(short id)
    {
        try
        {
            var category = await _categories.FindAsync(id);
            if (category == null || category.IsDeleted)
            {
                _logger.LogWarning("Attempted to change activation status of a non-existing or deleted category with ID {Id}", id);
                throw new KeyNotFoundException($"Category with ID {id} not found or is deleted.");
            }
            category.Active = !category.Active;
            category.UpdatedAt = DateTime.UtcNow;
            _categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error changing category activation status");
            throw;
        }
    }

}
