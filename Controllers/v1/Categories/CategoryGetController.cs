using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers.v1.Categories;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Categories")]
public class CategoryGetController : CategoryController
{
    private readonly CategoryServices CategoryServices;

    public CategoryGetController(CategoryServices CategoryServices): base(CategoryServices)
    {
        this.CategoryServices = CategoryServices;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
    {
        var categories = await CategoryServices.GetAll();
        if(categories.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            return Ok(categories);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetByIdACategory([FromRoute]int id)
    {
        if(await CategoryServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return Ok(await CategoryServices.GetById(id));
        }
    }
}