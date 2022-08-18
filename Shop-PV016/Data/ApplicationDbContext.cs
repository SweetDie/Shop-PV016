using Microsoft.EntityFrameworkCore;
using Shop_PV016.Models;

namespace Shop_PV016.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Processor", ShowOrder = 1 },
                new Category { Id = 2, Name = "Motherboard", ShowOrder = 1 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "AMD Ryzen 7 5700G", Description = "The world's best desktop processor delivers superior gaming performance.", Price = 700, CategoryId = 1, Image = "https://content1.rozetka.com.ua/goods/images/big_tile/247580065.jpg" },
                new Product { Id = 2, Name = "AMD Ryzen 5 1600", Description = "New AMD Zen Architecture Uses Powerful Execution Engine and Supports Simultaneous Multithreading (SMT)", Price = 250, CategoryId = 1, Image = "https://content1.rozetka.com.ua/goods/images/big_tile/247580065.jpg" },
                new Product { Id = 3, Name = "Intel Core i9-12900K", Description = "Unlocked 12th Gen Intel Core desktop processor optimized for enthusiast gamers and serious creators", Price = 900, CategoryId = 1, Image = "https://content1.rozetka.com.ua/goods/images/big_tile/247580065.jpg" },
                new Product { Id = 4, Name = "Asus Prime B550M-K", Description = "ASUS Prime series motherboards offer a reinforced power system, the ability to organize full-fledged component cooling, and intelligent configuration tools.", Price = 190, CategoryId = 2, Image = "https://content.rozetka.com.ua/goods/images/preview/231148231.jpg" },
                new Product { Id = 5, Name = "ASUS PRIME X570-P", Description = "The Prime X570 series is made for serious people who prefer to use their Ryzen processors for more productive work.", Price = 300, CategoryId = 2, Image = "https://content.rozetka.com.ua/goods/images/preview/231148231.jpg" },
                new Product { Id = 6, Name = "Gigabyte Z690 Aorus Elite", Description = "Z690 AORUS ELITE motherboard adopts 16+1+2 phase digital processor power supply scheme", Price = 350, CategoryId = 2, Image = "https://content.rozetka.com.ua/goods/images/preview/231148231.jpg" }
                );
        }
    }
}
