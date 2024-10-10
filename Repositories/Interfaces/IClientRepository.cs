using GestionDeProductosYServicios.Models;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IClientRepository
{
    Task<IEnumerable<Client>> GetAll();
    Task<Client> GetById(int id);
    Task Create(Client Client);
    Task Delete(int id);
    Task Update(Client Client);
    Task<bool> CheckExistence(int id);
}