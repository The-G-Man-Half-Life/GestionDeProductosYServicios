using GestionDeProductosYServicios.Repositories.Interfaces;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrierController : ControllerBase
{
    private readonly ICarrierRepository CarrierRepository;

    public CarrierController(ICarrierRepository CarrierRepository)
    {
        this.CarrierRepository = CarrierRepository;
    }
}