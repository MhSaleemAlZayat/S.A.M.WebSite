namespace S.A.M.Data.Entities;
public class Article
{
    public int Id { get; set; }
    public string AuthorId { get; set; } = string.Empty;
    public short CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public virtual ICollection<ArticleTranslation> Translations { get; set; } = new List<ArticleTranslation>();
}