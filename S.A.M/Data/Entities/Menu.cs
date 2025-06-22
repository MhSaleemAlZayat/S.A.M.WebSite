using System;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(64)]
        public string? Location { get; set; }

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
