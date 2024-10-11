using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products_orders")]
public class Product_OrderController : ControllerBase
{
    private readonly IProduct_OrderRepository Product_OrderRepository;

    public Product_OrderController(IProduct_OrderRepository Product_OrderRepository)
    {
        this.Product_OrderRepository = Product_OrderRepository;
    }
}