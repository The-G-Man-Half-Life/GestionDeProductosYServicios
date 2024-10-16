using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Seeders;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Data;
public class ApplicationDbcontext:DbContext
{
    public DbSet<Carrier> Carriers {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Client> Clients {get; set;}
    public DbSet<Shipment> Shipments {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<Shipment_Product> Shipment_Products {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<Product_Order> Products_Orders{get; set;}

    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // CarrierSeeder.Seed(modelBuilder);
        // CategorySeeder.Seed(modelBuilder);
        // ClientSeeder.Seed(modelBuilder);
        // ShipmentSeeder.Seed(modelBuilder);
        // ProductSeeder.Seed(modelBuilder);
        // ShipmentProductSeeder.Seed(modelBuilder);
        // OrderSeeder.Seed(modelBuilder);
        // ProductOrderSeeder.Seed(modelBuilder);
    }
} 