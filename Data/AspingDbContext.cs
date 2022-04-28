namespace Asping.Data
{
    using Asping.Model.Quotes;
    using Asping.Model.Locals;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class AspingDbContext : DbContext
    {
        public AspingDbContext(DbContextOptions<AspingDbContext> options): base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuoteTag> QuoteTags { get; set; }

        public DbSet<Predio> Predio { get; set; }
        public DbSet<Freguesia> Freguesia { get; set; }
        public DbSet<Concelho>  Concelho { get; set; }
        public DbSet<Distrito>  Distrito { get; set; }

        // Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.Relations(modelBuilder);
            this.Seed(modelBuilder);
        }

        private void Relations(ModelBuilder mb)
        {
            mb.Entity<Quote>()
                .HasOne(q => q.Author)
                .WithMany(a => a.Quotes)
                .HasForeignKey(q => q.AuthorId);

            mb.Entity<QuoteTag>()
                .HasKey(qt => new { qt.QuoteId, qt.TagId });

            mb.Entity<QuoteTag>()
                .HasOne(qt => qt.Quote)
                .WithMany(q => q.QuoteTags)
                .HasForeignKey(qt => qt.QuoteId);

            mb.Entity<QuoteTag>()
                .HasOne(qt => qt.Tag)
                .WithMany(t => t.QuoteTags)
                .HasForeignKey(qt => qt.TagId);
        }

        public void Seed(ModelBuilder mb)
        {
            var generalTag = new Tag() { Id = 1, Name = "General", Description = "General Description" };

            var lincoln = new Author() { Id = 2, Name = "Abraham Lincoln" };

            mb.Entity<Author>().HasData(new List<Author>()
            {
                new Author() { Id = 1, Name = "Albert Einstein" },
                lincoln
            });

            mb.Entity<Tag>().HasData(new List<Tag>() { generalTag }); 

            mb.Entity<Quote>().HasData(new List<Quote>()
            {
                new Quote()
                {
                    Id = 1,
                    AuthorId = 2,
                    When = new System.DateTime(1838, 1, 1),
                    Value = "America will never be destroyed from the outside"
                }
            });

            mb.Entity<QuoteTag>().HasData(new QuoteTag() { QuoteId = 1, TagId = generalTag.Id });
        }
    }
}
