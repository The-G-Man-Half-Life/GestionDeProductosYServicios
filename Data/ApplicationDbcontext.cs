using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Data;
public class ApplicationDbcontext:DbContext
{
    public DbSet<Carrier> Carriers {get; set;}

    public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
} 