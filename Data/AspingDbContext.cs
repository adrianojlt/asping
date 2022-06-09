namespace Asping.Data
{
    using Asping.Model.Quotes;
    using Asping.Model.Locals;
    using Microsoft.EntityFrameworkCore;

    public class AspingDbContext : DbContext
    {
        public AspingDbContext()
        {

        }

        public AspingDbContext(DbContextOptions<AspingDbContext> options): base(options)
        {

        }

        // QUOTES
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Quote> Quotes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuoteTag> QuoteTags { get; set; }

        // LOCALS
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
            mb.Entity<Author>().HasData(SeedQuotes.Authors);
            mb.Entity<Quote>().HasData(SeedQuotes.Quotes);
            mb.Entity<QuoteTag>().HasData(SeedQuotes.QuotesTags);
        }
    }
}
