using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository OrderRepository;

    public OrderController(IOrderRepository OrderRepository)
    {
        this.OrderRepository = OrderRepository;
    }
}