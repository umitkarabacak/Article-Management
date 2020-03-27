using ArticleManagement.Data.Mappings;
using ArticleManagement.Domain.DBOs;
using ArticleManagement.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArticleManagement.Data.Databases
{
    public class ProjectContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ArticleMappings());
            builder.ApplyConfiguration(new CommentMappings());
            builder.ApplyConfiguration(new AuthorMappings());
        }

    }
}