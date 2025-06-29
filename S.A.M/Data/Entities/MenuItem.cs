namespace S.A.M.Data.Entities;

public class MenuItem
{
    public short Id { get; set; }
    public byte MenuId { get; set; }
    public MenuItemType.MenuItemTypeEnum MenuItemTypeId { get; set; }
    public int? MenuItemTypeContentId { get; set; }
    public short? ParentId { get; set; }
    public byte SortOrder { get; set; }
    public string? CssClass { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool Active { get; set; } = true;

    public MenuItemType MenuItemType { get; set; }
}
