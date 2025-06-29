namespace S.A.M.Data.Entities
{
    public class TagTranslation
    {
        public short Id { get; set; }
        public short TagId { get; set; }
        public byte LanguageId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Slug { get; set; }


        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;

        public Tag Tag { get; set; }
    }
}
