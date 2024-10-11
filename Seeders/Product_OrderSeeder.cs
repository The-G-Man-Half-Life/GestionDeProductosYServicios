using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders;
public class ProductOrderSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productOrders = GenerateProductOrders(10);
        modelBuilder.Entity<Product_Order>().HasData(productOrders);
    }

    public static IEnumerable<Product_Order> GenerateProductOrders(int count)
    {
        int id = 1; 
        var faker = new Faker<Product_Order>()
            .RuleFor(po => po.Product_order_id, f => id++)
            .RuleFor(po => po.Product_quantity, f => f.Random.Int(1, 10)) 
            .RuleFor(po => po.Product_id, f => f.Random.Int(1, 10)) 
            .RuleFor(po => po.Order_id, f => f.Random.Int(1, 10)); 

        return faker.Generate(count);
    }
}

