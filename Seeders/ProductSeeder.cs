using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class ProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var products = GenerateProducts(10);
            modelBuilder.Entity<Product>().HasData(products);
        }

        public static IEnumerable<Product> GenerateProducts(int count)
        {
            int id = 1;
            var faker = new Faker<Product>()
                .RuleFor(p => p.Product_id, f => id++)
                .RuleFor(p => p.Product_name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Product_price, f => f.Random.Double(0,1000))
                .RuleFor(p => p.Product_description, f => f.Lorem.Sentence(10))
                .RuleFor(p => p.Category_id, f => f.Random.Int(1, 10));

            return faker.Generate(count);
        }
    }
}
