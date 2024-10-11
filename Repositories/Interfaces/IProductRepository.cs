using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<Product> GetById(int id);
    Task Create(Product Product);
    Task Delete(int id);
    Task Update(Product Product);
    Task<bool> CheckExistence(int id);
}