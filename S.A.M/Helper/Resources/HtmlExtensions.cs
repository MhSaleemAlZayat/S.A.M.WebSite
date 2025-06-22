using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace S.A.M.Herlper.Resources;

public static class HtmlExtensions
{
    /// <summary>
    /// Generates a CSS class for RTL/LTR direction
    /// </summary>
    public static string DirectionClass(this IHtmlHelper html, string ltrClass, string rtlClass)
    {
        var isRTL = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft;
        return isRTL ? rtlClass : ltrClass;
    }

    /// <summary>
    /// Generates dir attribute value based on current culture
    /// </summary>
    public static string DirectionAttribute(this IHtmlHelper html)
    {
        return CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ? "rtl" : "ltr";
    }

    /// <summary>
    /// Gets the current culture's two-letter ISO name
    /// </summary>
    public static string CurrentCulture(this IHtmlHelper html)
    {
        return CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
    }

    /// <summary>
    /// Checks if current culture is RTL
    /// </summary>
    public static bool IsRTL(this IHtmlHelper html)
    {
        return CultureInfo.CurrentCulture.TextInfo.IsRightToLeft;
    }
}
