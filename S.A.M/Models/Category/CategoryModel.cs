using S.A.M.Models.Common;

namespace S.A.M.Models.Category;

public class CategoryModel
{
    public short Id { get; set; }
    public CategoryModel ParentCategory { get; set; }
    public short? ParentId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool Active { get; set; } = true;
    public List<TranslationModel> Translations { get; set; } = new List<TranslationModel>();
}
