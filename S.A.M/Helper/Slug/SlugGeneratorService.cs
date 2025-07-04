using S.A.M.Helper.Slug.UniquenessCheckerPolicies;
using System.Text.RegularExpressions;

namespace S.A.M.Helper.Slug;

public class SlugGeneratorService : ISlugGenerator
{
    private readonly IEnumerable<IUniquenessCheckerPolicy> _uniquenessCheckerPolicies;
    public enum SlugType
    {
        Article,
        Category,
        Tag,
        User,
        Page, // For static pages
        Custom // For any other custom slug types
    }

    public SlugGeneratorService(IEnumerable<IUniquenessCheckerPolicy> uniquenessCheckerPolicies = null)
    {
        _uniquenessCheckerPolicies = uniquenessCheckerPolicies;
    }

    public async Task<string> GenerateSlugAsync(string input, SlugType type, byte languageId, bool ensureUnique = false)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be empty", nameof(input));

        string slug = Slugify(input);

        if (ensureUnique && _uniquenessCheckerPolicies is not null)
        {
            int counter = 1;
            string uniqueSlug = slug;
            var checkerPolicy = _uniquenessCheckerPolicies.FirstOrDefault(p => p.IsApplicableTo(type));
            while (!await checkerPolicy.IsUniqueAsync(uniqueSlug, languageId))
            {
                uniqueSlug = $"{slug}-{counter++}";
            }

            slug = uniqueSlug;
        }

        return slug;
    }

    private static string Slugify(string input)
    {
        // Convert to lowercase
        string result = input.ToLowerInvariant();

        // Keep Arabic, Latin, numbers and spaces only
        //result = Regex.Replace(result, @"[^\u0621-\u064A\u0660-\u0669a-zA-Z0-9\s]", ""); // Arabic + Latin + Arabic numbers

        // Remove unwanted punctuation and symbols but keep Arabic, Latin, digits, and spaces
        result = Regex.Replace(result, @"[^\u0621-\u064Aa-zA-Z0-9\s]", "");

        // Replace multiple spaces with hyphen
        result = Regex.Replace(result, @"\s+", "-");

        // Remove duplicate hyphens
        result = Regex.Replace(result, @"-+", "-").Trim('-');


        // Normalize accents
        //result = result.Normalize(NormalizationForm.FormD);
        //var sb = new StringBuilder();
        //foreach (var c in result)
        //{
        //    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
        //    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
        //        sb.Append(c);
        //}
        //result = sb.ToString().Normalize(NormalizationForm.FormC);

        //// Remove invalid characters
        //result = Regex.Replace(result, @"[^a-z0-9\s-]", "");

        //// Replace multiple spaces with a single hyphen
        //result = Regex.Replace(result, @"\s+", "-").Trim('-');

        //// Remove multiple hyphens
        //result = Regex.Replace(result, @"-+", "-");

        return result;
    }
}

