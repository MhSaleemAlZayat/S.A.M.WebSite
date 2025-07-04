using static S.A.M.Helper.Slug.SlugGeneratorService;

namespace S.A.M.Helper.Slug;

public interface ISlugGenerator
{
    /// <summary>
    /// Generates a slug from the input string.
    /// </summary>
    /// <param name="input">The raw string to slugify.</param>
    /// <param name="ensureUnique">Whether to ensure the slug is unique.</param>
    /// <returns>A URL-safe slug.</returns>
    Task<string> GenerateSlugAsync(string input, SlugType type, byte languageId, bool ensureUnique = false);
}