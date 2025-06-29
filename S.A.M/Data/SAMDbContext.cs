using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S.A.M.Data.Configurations;
using S.A.M.Data.Entities;
using S.A.M.Data.Entities.AspIdentity;

namespace S.A.M.Data
{
    public class SAMDbContext : IdentityDbContext<User, Role, string, UserClaim, UserRole, IdentityUserLogin<string>, RoleClaim, IdentityUserToken<string>>
    {
        public SAMDbContext(DbContextOptions<SAMDbContext> options)
            : base(options)
        {
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserClaim> UserClaim { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RoleClaim> RoleClaim { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleStatus> ArticleStatuses { get; set; }
        public DbSet<ArticleStatusTransaction> ArticleStatusTransactions { get; set; }
        public DbSet<ArticleTranslation> ArticleTranslations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<MenuLocation> MenuLocations { get; set; }
        public DbSet<MenuItemType> MenuItemTypes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemTranslation> MenuItemTranslations { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAMDbContext).Assembly);
            modelBuilder.SeedLanguageValues();
            modelBuilder.SeedCategoryValues();
            modelBuilder.SeedCategoryTranslationValues();
            modelBuilder.SeedArticleStatusValues();
            modelBuilder.SeedMenuLocationValues();
            modelBuilder.SeedMenuItemTypeValues();

        }
    }
}
