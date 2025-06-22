using System;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MenuId { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(512)]
        public string? Url { get; set; }

        public int? ParentId { get; set; }
        public int SortOrder { get; set; }

        [MaxLength(64)]
        public string? CssClass { get; set; }

        [MaxLength(32)]
        public string? Target { get; set; }

        [MaxLength(128)]
        public string? Icon { get; set; }

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
