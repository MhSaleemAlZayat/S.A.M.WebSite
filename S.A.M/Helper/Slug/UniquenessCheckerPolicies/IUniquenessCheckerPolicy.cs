namespace S.A.M.Helper.Slug.UniquenessCheckerPolicies;

public interface IUniquenessCheckerPolicy
{
    bool IsApplicableTo(SlugGeneratorService.SlugType type);
    Task<bool> IsUniqueAsync(string slug, byte languageId);
}
