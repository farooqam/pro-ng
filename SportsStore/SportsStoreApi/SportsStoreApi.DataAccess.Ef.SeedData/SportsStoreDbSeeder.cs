using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsStoreApi.DataAccess.Ef.SeedData
{
    public class SportsStoreDbSeeder
    {
        private static readonly Category[] Categories =
        {
            new Category {Name = "Watersports"},
            new Category {Name = "Soccer"},
            new Category {Name = "Chess"}
        };

        private static readonly Product[] Products =
        {
            new Product
            {
                ProductId = "KYK0001",
                Name = "Kayak",
                Description = "A boat for one person.",
                Price = 275m
            },
            new Product
            {
                ProductId = "LJX0001",
                Name = "Lifejacket",
                Description = "Protective and fashionable.",
                Price = 48.95m
            },
            new Product
            {
                ProductId = "SCR0001",
                Name = "Soccer ball",
                Description = "FIFA approved size and weight.",
                Price = 19.50m
            },
            new Product
            {
                ProductId = "SCR0002",
                Name = "Corner flags",
                Description = "Give your playing field a professional touch.",
                Price = 34.95m
            },
            new Product
            {
                ProductId = "SCR0003",
                Name = "Soccer Stadium",
                Description = "Flat packed 35,000 seat soccer stadium.",
                Price = 79500m
            },
            new Product
            {
                ProductId = "CHS0001",
                Name = "Thinking cap",
                Description = "Improve brain efficiency by 75%.",
                Price = 16m
            },
            new Product
            {
                ProductId = "CHS0002",
                Name = "Unsteady chair",
                Description = "Secretly give your opponent a disadvantage.",
                Price = 29.95m
            },
            new Product
            {
                ProductId = "CHS0003",
                Name = "Human chess board",
                Description = "A fun game for the family.",
                Price = 75m
            },
            new Product
            {
                ProductId = "CHS0004",
                Name = "Bling bling king",
                Description = "Gold plated, diamond studded king.",
                Price = 1200m
            }
        };

        private static readonly ProductCategorization[] ProductCategorizations =
        {
            new ProductCategorization
            {
                CategoryName = "Watersports",
                ProductId = "KYK0001"
            },
            new ProductCategorization
            {
                CategoryName = "Watersports",
                ProductId = "LJX0001"
            },
            new ProductCategorization
            {
                CategoryName = "Soccer",
                ProductId = "SCR0001"
            },
            new ProductCategorization
            {
                CategoryName = "Soccer",
                ProductId = "SCR0002"
            },
            new ProductCategorization
            {
                CategoryName = "Soccer",
                ProductId = "SCR0003"
            },
            new ProductCategorization
            {
                CategoryName = "Chess",
                ProductId = "CHS0001"
            },
            new ProductCategorization
            {
                CategoryName = "Chess",
                ProductId = "CHS0002"
            },
            new ProductCategorization
            {
                CategoryName = "Chess",
                ProductId = "CHS0003"
            },
            new ProductCategorization
            {
                CategoryName = "Chess",
                ProductId = "CHS0004"
            }
        };

        public static void SeedData(SportsStoreDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Count() != 0) return;

            dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Categories.AddRange(Categories);
                dbContext.Products.AddRange(Products);
                dbContext.SaveChanges();

                dbContext.ProductCategorizations.AddRange(ProductCategorizations);
                dbContext.SaveChanges();
                dbContext.Database.CommitTransaction();
            }
            catch (Exception)
            {
                dbContext.Database.RollbackTransaction();
            }
        }

        public static void ClearData(SportsStoreDbContext dbContext)
        {
            if (dbContext.ProductCategorizations.Any())
                dbContext.ProductCategorizations.RemoveRange(dbContext.ProductCategorizations);

            if (dbContext.Products.Any()) dbContext.Products.RemoveRange(dbContext.Products);

            if (dbContext.Categories.Any()) dbContext.Categories.RemoveRange(dbContext.Categories);

            dbContext.SaveChanges();
        }
    }
}