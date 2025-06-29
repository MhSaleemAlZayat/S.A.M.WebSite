namespace S.A.M.Data.Entities;

public class MenuItemTranslation
{
    public short Id { get; set; }
    public byte MenuItemId { get; set; }
    public byte LanguageId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int? MenuItemTypeTranslatedContentId { get; set; }
    public string? Url { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool Active { get; set; } = true;
}
