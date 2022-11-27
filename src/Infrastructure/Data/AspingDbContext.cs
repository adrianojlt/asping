namespace Infrastructure.Data;

using Infrastructure.Model.Quotes;
using Infrastructure.Model.Locals;
using Microsoft.EntityFrameworkCore;

public class AspingDbContext : DbContext
{
    public AspingDbContext() { }

    public AspingDbContext(DbContextOptions<AspingDbContext> options): base(options) { }

    // QUOTES
    public virtual DbSet<Author>? Authors { get; set; }
    public virtual DbSet<Quote>? Quotes { get; set; }
    public virtual DbSet<Tag>? Tags { get; set; }
    public virtual DbSet<QuoteTag>? QuoteTags { get; set; }

    // LOCALS
    public virtual DbSet<Predio>? Predio { get; set; }
    public virtual DbSet<Freguesia>? Freguesia { get; set; }
    public virtual DbSet<Concelho>?  Concelho { get; set; }
    public virtual DbSet<Distrito>?  Distrito { get; set; }

    // Fluent Api
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.Relations(modelBuilder);
        this.Seed(modelBuilder);
    }

    private void Relations(ModelBuilder mb)
    {
        // We only need to specify these Primary Keys,
        // in the others class models the Id fields are PK by convention
        mb.Entity<QuoteTag>().HasKey(qt => new { qt.QuoteId, qt.TagId });

        mb.Entity<Quote>()
            .HasOne(q => q.Author)
            .WithMany(a => a.Quotes)
            .HasForeignKey(q => q.AuthorId);

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
        mb.Entity<Tag>().HasData(SeedQuotes.Tags);
        mb.Entity<Quote>().HasData(SeedQuotes.Quotes);
        mb.Entity<QuoteTag>().HasData(SeedQuotes.QuotesTags);
    }
}
