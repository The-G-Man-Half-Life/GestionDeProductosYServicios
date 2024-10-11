using Bogus;
using GestionDeProductosYServicios.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Seeders
{
    public class ClientSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var clients = GenerateClients(10);
            modelBuilder.Entity<Client>().HasData(clients);
        }

        public static IEnumerable<Client> GenerateClients(int count)
        {
            int id = 1; 
            var faker = new Faker<Client>()
                .RuleFor(c => c.Client_id, f => id++)
                .RuleFor(c => c.Client_name, f => f.Name.FullName()) 
                .RuleFor(c => c.Client_address, f => f.Address.FullAddress()) 
                .RuleFor(c => c.Client_contact, f => f.Phone.PhoneNumber()); 

            return faker.Generate(count);
        }
    }
}
