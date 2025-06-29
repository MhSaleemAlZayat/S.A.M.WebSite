namespace S.A.M.Data.Entities;

public class ArticleTranslation
{
    public int Id { get; set; }
    public int ArticleId { get; set; }
    public byte LanguageId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? FeatureImageUrl { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; } = false;
    public bool Active { get; set; } = true;

    public virtual Article Article { get; set; } = null!;
    public virtual ICollection<ArticleStatusTransaction> StatusTransactions { get; set; } = new List<ArticleStatusTransaction>();
}
