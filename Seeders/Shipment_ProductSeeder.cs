using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class ShipmentProductSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var shipmentProducts = GenerateShipmentProducts(10);
            modelBuilder.Entity<Shipment_Product>().HasData(shipmentProducts);
        }

        public static IEnumerable<Shipment_Product> GenerateShipmentProducts(int count)
        {
            int id = 1;
            var faker = new Faker<Shipment_Product>()
                .RuleFor(sp => sp.Shipment_Product_id, f => id++)
                .RuleFor(sp => sp.Product_amount, f => f.Random.Int(1, 100))
                .RuleFor(sp => sp.Product_id, f => f.Random.Int(1, 10))
                .RuleFor(sp => sp.Shipment_id, f => f.Random.Int(1, 10));

            return faker.Generate(count);
        }
    }
}
