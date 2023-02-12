using Artisanale.Services.ProductApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Artisanale.Services.ProductApi.DbContexts
{
    public class ApplicationDbContest:DbContext
    {
        //ctor
        public ApplicationDbContest(DbContextOptions options):base(options)
        {


        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Libelle = "chaiseBoisMassif",
                    Price = 15,
                    CategoryName = "",
                    ImageUrl = ""
                });
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   ProductId = 2,
                   Libelle = "ch",
                   Price = 15,
                   CategoryName = "",
                   ImageUrl = ""
               });
        }

    }
}
