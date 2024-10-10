using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface ICarrierRepository
{
    Task<IEnumerable<Carrier>> GetAll();
    Task<Carrier> GetById(int id);
    Task Create(Carrier Carrier);
    Task Delete(int id);
    Task Update(Carrier Carrier);
    Task<bool> CheckExistence(int id);
}