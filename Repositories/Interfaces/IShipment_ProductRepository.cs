using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeShipment_ProductosYServicios.Repositories.Interfaces;
public interface IShipment_ProductRepository
{
    Task<IEnumerable<Shipment_Product>> GetAll();
    Task<Shipment_Product> GetById(int id);
    Task Create(Shipment_Product Shipment_Product);
    Task Delete(int id);
    Task Update(Shipment_Product Shipment_Product);
    Task<bool> CheckExistence(int id);
}