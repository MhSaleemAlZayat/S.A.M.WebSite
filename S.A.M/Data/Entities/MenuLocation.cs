using System.ComponentModel;

namespace S.A.M.Data.Entities;

public class MenuLocation
{
    public enum MenuLocationEnum : byte
    {
        [Description("القائمة الرئيسية: القائمة الرئيسية للموقع.")]
        MainMenu = 1,
        [Description("القائمة السفلية: قائمة الروابط في أسفل الصفحة.")]
        FooterMenu = 2,
        [Description("القائمة الجانبية: قائمة تظهر في الجانب الأيسر أو الأيمن من الصفحة.")]
        SidebarMenu = 3,
        [Description("القائمة العلوية: قائمة تظهر في أعلى الصفحة.")]
        HeaderMenu = 4,
        [Description("قائمة مخصصة: قوائم يمكن تخصيصها حسب الحاجة.")]
        CustomMenu = 5
    }

    public MenuLocationEnum Id { get; set; }
    public MenuLocationEnum Name { get; set; }
    public string? Description { get; set; }
    public Menu Menu { get; set; }
}
