using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevCookBookASP.Models
{
    public class RevCookBookContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Language> Languages { get; set; }


        public RevCookBookContext(DbContextOptions<RevCookBookContext> options)
            : base(options)
        { }

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(x => new { x.CategoryId });

            modelBuilder.Entity<Ingredient>()
                .HasKey(x => new { x.IngredientId });

            modelBuilder.Entity<Dish>()
                .HasKey(x => new { x.DishId });

            modelBuilder.Entity<Recipe>()
                .HasKey(x => new { x.RecipeId });

            modelBuilder.Entity<Language>()
                .HasKey(x => new { x.LanguageId });

            modelBuilder.Entity<DishIngredient>()
                .HasKey(x => new { x.DishId, x.IngredientId});

            modelBuilder.Entity<DishIngredient>()
                .HasOne(pt => pt.Dish)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(pt => pt.DishId);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.Dishes)
                .HasForeignKey(pt => pt.IngredientId);

            modelBuilder.Entity<IngredientCategory>()
                .HasKey(x => new { x.CategoryId, x.IngredientId });

            modelBuilder.Entity<IngredientCategory>()
                .HasOne(pt => pt.Category)
                .WithMany(p => p.Ingredients)
                .HasForeignKey(pt => pt.CategoryId);

            modelBuilder.Entity<IngredientCategory>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.Categories)
                .HasForeignKey(pt => pt.IngredientId);

            seedData(modelBuilder);
        }

        protected void seedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Chleb" },
                new Ingredient { IngredientId = 2, Name = "Masło" }
            );

            modelBuilder.Entity<Language>().HasData(new Language[]
            {
                new Language() { LanguageId = 1, LanguageCode = "EN" },
                new Language() { LanguageId = 2, LanguageCode = "PL" }
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Pieczywo" },
                new Category { CategoryId = 2, Name = "Nabiał" }
            );

            modelBuilder.Entity<Dish>().HasData(
                new Dish { DishId = 1, Name = "Kanapka z masłem", Time = "2 min" }

            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    RecipeId = 1,
                    Text = "Do a sandwitch",
                    LanguageId = 1,
                    DishId = 1
                },
                new Recipe
                {
                    RecipeId = 2,
                    Text = "Zrób kanapkę",
                    LanguageId = 2,
                    DishId = 1
                }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1, Amount = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2, Amount = 1 }
            );

            modelBuilder.Entity<IngredientCategory>().HasData(
                new IngredientCategory { CategoryId = 1, IngredientId = 1 },
                new IngredientCategory { CategoryId = 1, IngredientId = 2 }
            );
        }
    }
}
