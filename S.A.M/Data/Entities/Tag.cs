namespace S.A.M.Data.Entities
{
    public class Tag
    {
        public short Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;

        public virtual ICollection<TagTranslation> Translations { get; set; }
    }
}
