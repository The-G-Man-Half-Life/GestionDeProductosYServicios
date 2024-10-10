using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Controllers.v1.Categories;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Categories")]
public class CategoryCreateController : ControllerBase
{
    private readonly CategoryServices CategoryServices;

    public CategoryCreateController(CategoryServices CategoryServices)
    {
        this.CategoryServices = CategoryServices;
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateANewCategory([FromBody] CategoryDTO CategoryDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if(CategoryDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newCategory = new Category{
                    Category_name = CategoryDTO.Category_name,
                    Category_description = CategoryDTO.Category_description
                };
                await CategoryServices.Create(newCategory);
                return Ok(newCategory);
            }
            catch (DbUpdateException dbEX)
            {
                
                throw new DbUpdateException("Un erro ocurrio",dbEX);
            }
        }
    }
}