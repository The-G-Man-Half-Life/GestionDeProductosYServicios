using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Controllers.v1.Categories
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Categories")]
    public class CategoryUpdateController : CategoryController
    {
        private readonly CategoryServices CategoryServices;

        public CategoryUpdateController(CategoryServices CategoryServices):base(CategoryServices)
        {
            this.CategoryServices = CategoryServices;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateACategory([FromRoute]int id,[FromBody]CategoryDTO CategoryDTO)
        {
            if(ModelState.IsValid ==false)
            {
                return BadRequest();
            }
            else if (await CategoryServices.CheckExistence(id) == false)
            {
                return NoContent();    
            }
            else if(CategoryDTO == null)
            {
                return NoContent();
            }
            else
            {
                try
                {
                    var categoryFound = await CategoryServices.GetById(id);
                    categoryFound.Category_name = CategoryDTO.Category_name;
                    categoryFound.Category_description = CategoryDTO.Category_description;
                    await CategoryServices.Update(categoryFound);
                    return Ok("Actualizada exitosamente");

                }
            catch (DbUpdateException dbEX)
            {
                
                throw new DbUpdateException("Un erro ocurrio",dbEX);
            }
            }
        }
    }
}