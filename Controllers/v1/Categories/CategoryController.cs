using GestionDeProductosYServicios.Repositories.Interfaces;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers.v1.Categories;


[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Categories")]
public class CategoryController : ControllerBase
{
    private readonly CategoryServices CategoryServices;

    public CategoryController(CategoryServices CategoryServices)
    {
        this.CategoryServices = CategoryServices;
    }
}