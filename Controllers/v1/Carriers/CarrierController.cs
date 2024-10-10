using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/Carriers/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierController : ControllerBase
{
    private readonly ICarrierRepository CarrierRepository;

    public CarrierController(ICarrierRepository CarrierRepository)
    {
        this.CarrierRepository = CarrierRepository;
    }
}