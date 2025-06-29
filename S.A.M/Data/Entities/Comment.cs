using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int ArticleTranslationId { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsApproved { get; set; } = false;

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
