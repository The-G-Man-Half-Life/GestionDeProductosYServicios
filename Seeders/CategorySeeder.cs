using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class CategorySeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var categories = GenerateCategories(10);
            modelBuilder.Entity<Category>().HasData(categories);
        }

        public static IEnumerable<Category> GenerateCategories(int count)
        {
            int id = 1;
            var faker = new Faker<Category>()
                .RuleFor(c => c.Category_id, f => id++)
                .RuleFor(c => c.Category_name, f => f.Commerce.Categories(1)[0]) 
                .RuleFor(c => c.Category_description, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }
    }
}
