namespace asping.Data
{
    using asping.Model;
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

        // Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Author)
                .WithMany(a => a.Quotes).HasForeignKey(q => q.AuthorId);


            modelBuilder.Entity<Author>().HasData(new List<Author>()
            {
                new Author() { Id = 1, Name = "Albert Einstein" },
                new Author() { Id = 2, Name = "Abraham Lincoln" }
            });

            modelBuilder.Entity<Tag>().HasData(new List<Tag>() 
            { 
               new Tag() { Id = 1, Name = "General", Description = "General Description" }
            });

            modelBuilder.Entity<Quote>().HasData(new List<Quote>()
            {
                new Quote()
                {
                    Id = 1,
                    When = new System.DateTime(1838, 1, 1),
                    Value = "America will never be destroyed from the outside",
                    AuthorId = 2
                }
            });

            modelBuilder.Entity("QuoteTag").HasData( 
                new { QuotesId = 1, TagsId = 1 }  
            );
        }

    }
}
