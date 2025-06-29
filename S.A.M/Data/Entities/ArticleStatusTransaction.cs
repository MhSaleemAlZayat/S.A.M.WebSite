namespace S.A.M.Data.Entities;

public class ArticleStatusTransaction
{
    public int Id { get; set; }
    public int ArticleTranslationId { get; set; }
    public ArticleStatus.ArticleStatusEnum StatusId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public virtual ArticleTranslation ArticleTranslation { get; set; } = null!;
}