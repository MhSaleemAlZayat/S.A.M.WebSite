namespace S.A.M.Models.Common;

public class TranslationModel
{
    public int Id { get; set; }
    public byte LanguageId { get; set; }
    public int MasterId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Slug { get; set; }
    public string? Description { get; set; }

    public bool Active { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
