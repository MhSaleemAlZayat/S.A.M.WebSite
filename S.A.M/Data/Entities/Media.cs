using System;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public class Media
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string FileName { get; set; } = string.Empty;

        [Required, MaxLength(512)]
        public string Url { get; set; } = string.Empty;

        [MaxLength(1024)]
        public string? FilePath { get; set; }

        public long FileLength { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        [MaxLength(256)]
        public string? AlternativeText { get; set; }

        [MaxLength(128)]
        public string? ContentType { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(32)]
        public string? CreatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
