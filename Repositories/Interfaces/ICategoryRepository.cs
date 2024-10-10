using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAll();
    Task<Category> GetById(int id);
    Task Create(Category Category);
    Task Delete(int id);
    Task Update(Category Category);
    Task<bool> CheckExistence(int id);
}