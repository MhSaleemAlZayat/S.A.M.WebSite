using S.A.M.Data.Entities;

namespace S.A.M.Data.Repositories.Categories;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(short id);
    Task<Category?> GetCategoryByNameAsync(string name);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(short id);

    Task<Category> ChangeCategoryActivationStatusAsync(short id);



}
