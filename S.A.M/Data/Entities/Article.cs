using System;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities
{
    public enum ArticleStatus
    {
        Draft,
        Published,
        Private
    }

    public class Article
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

        [MaxLength(64)]
        public string AuthorId { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? PublishedAt { get; set; }

        [Required]
        public ArticleStatus Status { get; set; } = ArticleStatus.Draft;
    }
}
