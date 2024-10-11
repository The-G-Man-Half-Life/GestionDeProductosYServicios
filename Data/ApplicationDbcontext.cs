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

    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // CarrierSeeder.Seed(modelBuilder);
    }
} 