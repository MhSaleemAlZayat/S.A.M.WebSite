
using S.A.M.Data.Repositories.Categories;

namespace S.A.M.Helper.Slug.UniquenessCheckerPolicies;

public class CategoryUniquenessCheckerPolicy : IUniquenessCheckerPolicy
{
    public bool IsApplicableTo(SlugGeneratorService.SlugType type)
        => type == SlugGeneratorService.SlugType.Category;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryUniquenessCheckerPolicy(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> IsUniqueAsync(string slug, byte languageId)
    {
        return await _categoryRepository.CheckSlugUniqueness(slug, languageId);
    }
}
