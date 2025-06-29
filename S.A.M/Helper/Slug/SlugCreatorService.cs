using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace S.A.M.Helper.Slug
{
    public interface ISlugCreatorService
    {
        string GenerateSlug(string phrase);
    }

    public class SlugCreatorService : ISlugCreatorService
    {
        public string GenerateSlug(string phrase)
        {
            if (string.IsNullOrWhiteSpace(phrase))
                return string.Empty;

            // Convert to lower case
            string str = phrase.ToLowerInvariant();

            // Normalize the string to decompose accented characters
            str = str.Normalize(NormalizationForm.FormD);

            // Remove diacritics (accents)
            var sb = new StringBuilder();
            foreach (var c in str)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }
            str = sb.ToString().Normalize(NormalizationForm.FormC);

            // Remove invalid characters (keep Arabic, English, numbers, and hyphens)
            str = Regex.Replace(str, @"[^a-z0-9\u0600-\u06FF\s-]", "");

            // Replace multiple spaces or hyphens with a single hyphen
            str = Regex.Replace(str, @"[\s-]+", "-").Trim('-');

            return str;
        }
    }
}