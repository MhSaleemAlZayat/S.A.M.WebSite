
namespace S.A.M.Helper.Slug.UniquenessCheckerPolicies;

public class ArticleUniquenessCheckerPolicy : IUniquenessCheckerPolicy
{
    public bool IsApplicableTo(SlugGeneratorService.SlugType type)
        => type == SlugGeneratorService.SlugType.Article;

    public async Task<bool> IsUniqueAsync(string slug, byte languageId)
    {
        return await Task.Run(() =>
        {
            // Simulate a database check for uniqueness
            // In a real application, this would query the database to check if the slug already exists
            // For demonstration purposes, let's assume all slugs are unique
            return true; // Replace with actual uniqueness check logic
        });
    }
}
