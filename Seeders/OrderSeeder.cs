using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class OrderSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var orders = GenerateOrders(10);
            modelBuilder.Entity<Order>().HasData(orders);
        }

        public static IEnumerable<Order> GenerateOrders(int count)
        {
            int id = 1; 
            var faker = new Faker<Order>()
                .RuleFor(o => o.Order_id, f => id++)
                .RuleFor(o => o.Order_creation_date, f => f.Date.PastDateOnly(1))
                .RuleFor(o => o.Order_delivery_date, f => f.Date.FutureDateOnly(1)) 
                .RuleFor(o => o.Client_id, f => f.Random.Int(1, 10))
                .RuleFor(o => o.Carrier_id, f => f.Random.Int(1, 10));

            return faker.Generate(count);
        }
    }
}
