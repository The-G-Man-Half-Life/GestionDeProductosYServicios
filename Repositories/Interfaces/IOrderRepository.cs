using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAll();
    Task<Order> GetById(int id);
    Task Create(Order Order);
    Task Delete(int id);
    Task Update(Order Order);
    Task<bool> CheckExistence(int id);
}