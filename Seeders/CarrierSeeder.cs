using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders;
public class CarrierSeeder
{
    public static void Seed(ModelBuilder ModelBuilder)
    {
        var Carriers = GenerateCarriers(5);
        ModelBuilder.Entity<Carrier>().HasData(Carriers);
    }

    public static IEnumerable<Carrier> GenerateCarriers(int count)
    {
        int id = 2;
        var faker = new Faker<Carrier>()
        .RuleFor(g=>g.Carrier_id,f=>id++)
        .RuleFor(g=>g.Carrier_name,f=>f.Name.FirstName())
        .RuleFor(g=>g.Carrier_description,f=>f.Lorem.Sentence());
        return faker.Generate(count);
    }
};