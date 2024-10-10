using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Repositories.Interfaces;
public interface ICarrierRepository
{
    Task<IEnumerable<Carrier>> GetAll();
    Task<Carrier> GetById(int id);
    Task<IActionResult> Create(CarrierDTO CarrierDTO);
    Task<IActionResult> Delete(int id);
    Task<IActionResult> Update(CarrierDTO CarrierDTO);
    Task<bool> CheckExistence(int id);
}