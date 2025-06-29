namespace S.A.M.Data.Entities
{
    public class Language
    {
        public byte Id { get; set; }
        public string Code { get; set; } = string.Empty; // e.g. "en", "ar", "fr"
        public string Name { get; set; } = string.Empty; // e.g. "English", "العربية", "Français"
        public string? Culture { get; set; } // e.g. "en-US", "ar-SY"
        public byte SortOrder { get; set; } = 0;
        public bool Default { get; set; } = false; // Indicates if this is the default language
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;

    }
}