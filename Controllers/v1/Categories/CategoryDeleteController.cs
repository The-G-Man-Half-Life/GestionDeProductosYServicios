
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Controllers.v1.Categories;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Categories")]
public class CategoryDeleteController : CategoryController
{
    private readonly CategoryServices CategoryServices;

    public CategoryDeleteController(CategoryServices CategoryServices): base(CategoryServices)
    {
        this.CategoryServices = CategoryServices;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteACategory([FromRoute]int id)
    {
        if(await CategoryServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            try
            {
                await CategoryServices.Delete(id);
                return Ok("borrado exitosamente");
            }
            catch (DbUpdateException dbEX)
            {
                
                throw new DbUpdateException("Un erro ocurrio",dbEX);
            }
        }
    }
}