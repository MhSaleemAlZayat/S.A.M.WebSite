using System;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public class Page
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Title { get; set; } = string.Empty;

        [Required, MaxLength(256)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? FeatureImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [MaxLength(32)]
        public string? CreatedBy { get; set; }
        [MaxLength(32)]
        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}
