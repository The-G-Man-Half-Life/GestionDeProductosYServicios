using GestionDeProductosYServicios.Repositories.Interfaces;
using GestionDeShipment_ProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments_Products")]
public class Shipment_ProductController : ControllerBase
{
    private readonly IShipment_ProductRepository Shipment_ProductRepository;

    public Shipment_ProductController(IShipment_ProductRepository Shipment_ProductRepository)
    {
        this.Shipment_ProductRepository = Shipment_ProductRepository;
    }
}