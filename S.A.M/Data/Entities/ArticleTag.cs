namespace S.A.M.Data.Entities
{
    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public short TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
