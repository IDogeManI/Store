using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using StoreBack.Models;

namespace StoreBack
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<Product>().HasData
                (
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png",99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99),
                    new Product("Boots",
                    "Lorem ipsum dolor sit amet, consectetur adipisicing elit." +
                    " Suscipit sequi possimus accusamus error deleniti," +
                    " impedit voluptatibus officiis repellat fuga harum deserunt temporibus" +
                    " eius tempore reiciendis quas quaerat minus perferendis! Placeat?", "../../assets/backet.png", 99)
                );
        }
    }
}
