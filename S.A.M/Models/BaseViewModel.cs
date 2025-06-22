using System.Globalization;

namespace S.A.M.Models;

public abstract class BaseViewModel
{
    public string CurrentCulture => CultureInfo.CurrentCulture.Name;
    public bool IsRTL => CultureInfo.CurrentCulture.TextInfo.IsRightToLeft;
    public string Direction => IsRTL ? "rtl" : "ltr";
}