
namespace S.A.M.Helper.Slug.UniquenessCheckerPolicies;

public class PageUniquenessCheckerPolicy : IUniquenessCheckerPolicy
{
    public bool IsApplicableTo(SlugGeneratorService.SlugType type)
        => type == SlugGeneratorService.SlugType.Page;

    public Task<bool> IsUniqueAsync(string slug, byte languageId)
    {
        throw new NotImplementedException();
    }
}
