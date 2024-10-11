using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IProduct_orderRepository
{
    Task<IEnumerable<Product_order>> GetAll();
    Task<Product_order> GetById(int id);
    Task Create(Product_order Product_order);
    Task Delete(int id);
    Task Update(Product_order Product_order);
    Task<bool> CheckExistence(int id);
}