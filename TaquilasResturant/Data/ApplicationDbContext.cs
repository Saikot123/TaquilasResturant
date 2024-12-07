using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaquilasResturant.Models;
using TequliasRestaurant.Models;

namespace TaquilasResturant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ProductIngredient> ProductIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            ModelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            ModelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);

            ModelBuilder.Entity<ProductIngredient>()
               .HasOne(pi => pi.Ingredient)
               .WithMany(i => i.ProductIngredients)
               .HasForeignKey(pi => pi.IngredientId);

            ModelBuilder.Entity<Category>().HasData(
                new Category { CartegoryId = 1, Name = "Appetizer" },
                new Category { CartegoryId = 2, Name = "Entree" },
                new Category { CartegoryId = 3, Name = "Side Dish" },
                new Category { CartegoryId = 4, Name = "Dessert" },
                new Category { CartegoryId = 5, Name = "Bevreage" }
            );

            ModelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" },
                new Ingredient { IngredientId = 2, Name = "Chiken" },
                new Ingredient { IngredientId = 3, Name = "Fish" },
                new Ingredient { IngredientId = 4, Name = "Tortilla" },
                new Ingredient { IngredientId = 5, Name = "Letuce" },
                new Ingredient { IngredientId = 6, Name = "Tomato" }
            );

            ModelBuilder.Entity<Product>().HasData(
                
                new Product
                {
                    ProductId = 1,
                    Name = "Beef Taco",
                    Description = "Delicious",
                    Price = 2.50m,
                    Stock = 102,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 2,
                    Name = "Chicke Taco",
                    Description = "Delicious",
                    Price = 2.52m,
                    Stock = 100,
                    CategoryId = 2
                },

                new Product
                {
                    ProductId = 3,
                    Name = "Fish Taco",
                    Description = "Delicious",
                    Price = 3.99m,
                    Stock = 90,
                    CategoryId = 2
                }
            );

            ModelBuilder.Entity<ProductIngredient>().HasData(
                new ProductIngredient { ProductId = 1,IngredientId = 1},
                new ProductIngredient { ProductId = 1, IngredientId = 4 },
                new ProductIngredient { ProductId = 1, IngredientId = 5 },
                new ProductIngredient { ProductId = 1, IngredientId = 6 },

                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },

                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 }
            );
        }
    }
}
