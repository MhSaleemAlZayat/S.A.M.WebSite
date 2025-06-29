namespace S.A.M.Data.Entities;

public class MenuItemType
{
    public enum MenuItemTypeEnum : byte
    {
        [System.ComponentModel.Description("رابط: عنصر قائمة بسيط يوجه إلى عنوان URL.")]
        Link = 1,
        [System.ComponentModel.Description("مقالة: عنصر قائمة يوجه إلى مقالة.")]
        Artile = 2,
        [System.ComponentModel.Description("صحفة: عنصر قائمة يوجه إلى صفحة.")]
        Page = 3,
        [System.ComponentModel.Description("تصنيف: عنصر مقالة يوجة إلى تصنيف.")]
        Cateogry = 4,
    }
    public MenuItemTypeEnum Id { get; set; }
    public MenuItemTypeEnum Name { get; set; }
    public string? Description { get; set; }

    public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
