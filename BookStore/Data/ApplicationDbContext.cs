using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // To create a table in you database we are using DbSet.
        // For that we need to do migration Tools --> NuGet Package Manager --> Package Manger Console
        // add-migration AddCategoryTableToDb
        // update-database
        //add-migration-SeedCategoryTable
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
