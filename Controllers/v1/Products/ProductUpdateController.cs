using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products")]
public class ProductUpdateController : ProductController
{
    private readonly ProductServices ProductServices;
    
    public ProductUpdateController(ProductServices ProductServices): base(ProductServices)
    {
        this.ProductServices = ProductServices;
    }

    /// <summary>
    /// Updates an existing Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product to update.</param>
    /// <param name="ProductDTO">The updated Product data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Product updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Product is not found or if ProductDTO is null).</response>
    /// <response code="404">Product not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Product", Description = "Allows the user to update a Product.")]
    [SwaggerResponse(200, "Product updated successfully.", typeof(Product))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateProduct([FromRoute]int id,[FromBody]ProductDTO ProductDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ProductDTO == null)
        {
            return NoContent();
        }
        else if (await ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundProduct = await ProductServices.GetById(id);

            foundProduct.Product_name = ProductDTO.Product_name;
            foundProduct.Product_price = ProductDTO.Product_price;
            foundProduct.Product_description = ProductDTO.Product_description;
            foundProduct.Category_id = ProductDTO.Category_id;

            await ProductServices.Update(foundProduct);
            return Ok("Se actualizo exitosamente");
        }
    } 
}