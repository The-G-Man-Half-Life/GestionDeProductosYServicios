using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository ProductRepository;

    public ProductController(IProductRepository ProductRepository)
    {
        this.ProductRepository = ProductRepository;
    }
}