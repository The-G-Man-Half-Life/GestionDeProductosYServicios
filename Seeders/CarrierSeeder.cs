using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class CarrierSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var carriers = GenerateCarriers(10);
            modelBuilder.Entity<Carrier>().HasData(carriers);
        }

        public static IEnumerable<Carrier> GenerateCarriers(int count)
        {
            int id = 1;
            var faker = new Faker<Carrier>()
                .RuleFor(g => g.Carrier_id, f => id++)
                .RuleFor(g => g.Carrier_name, f => f.Name.FirstName())
                .RuleFor(g => g.Carrier_description, f => f.Lorem.Sentence());

            return faker.Generate(count);
        }
    }
}
