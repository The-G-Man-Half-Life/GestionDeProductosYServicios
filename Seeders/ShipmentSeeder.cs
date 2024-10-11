using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class ShipmentSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var shipments = GenerateShipments(10);
            modelBuilder.Entity<Shipment>().HasData(shipments);
        }

        public static IEnumerable<Shipment> GenerateShipments(int count)
        {
            int id = 1;
            var faker = new Faker<Shipment>()
                .RuleFor(s => s.Shipment_id, f => id++)
                .RuleFor(s => s.Shipment_weight_kg, f => f.Random.Double(1.0, 100.0))
                .RuleFor(s => s.Shipment_price_usa, f => f.Random.Double(10.0, 500.0))
                .RuleFor(s => s.Shipment_order_date, f => f.Date.PastDateOnly(1))
                .RuleFor(s => s.Shipment_arrival_date, f => f.Date.PastDateOnly(1))
                .RuleFor(s => s.Carrier_id, f => f.Random.Int(1, 10));

            return faker.Generate(count);
        }
    }
}
