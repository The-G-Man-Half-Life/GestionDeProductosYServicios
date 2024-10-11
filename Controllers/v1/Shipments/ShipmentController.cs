using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments")]
public class ShipmentController : ControllerBase
{
    private readonly IShipmentRepository ShipmentRepository;

    public ShipmentController(IShipmentRepository ShipmentRepository)
    {
        this.ShipmentRepository = ShipmentRepository;
    }
}