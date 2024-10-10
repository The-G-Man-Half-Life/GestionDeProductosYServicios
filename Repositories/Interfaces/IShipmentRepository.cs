using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IShipmentRepository
{
    Task<IEnumerable<Shipment>> GetAll();
    Task<Shipment> GetById(int id);
    Task Create(Shipment Shipment);
    Task Delete(int id);
    Task Update(Shipment Shipment);
    Task<bool> CheckExistence(int id);
}