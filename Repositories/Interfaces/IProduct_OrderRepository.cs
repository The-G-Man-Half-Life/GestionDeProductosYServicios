using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IProduct_OrderRepository
{
    Task<IEnumerable<Product_Order>> GetAll();
    Task<Product_Order> GetById(int id);
    Task Create(Product_Order Product_Order);
    Task Delete(int id);
    Task Update(Product_Order Product_Order);
    Task<bool> CheckExistence(int id);
}