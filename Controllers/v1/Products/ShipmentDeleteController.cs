using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products")]
public class ProductDeleteController : ProductController
{
    private readonly ProductServices ProductServices;

    public ProductDeleteController(ProductServices ProductServices) : base(ProductServices)
    {
        this.ProductServices = ProductServices;
    }

    /// <summary>
    /// Deletes a Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Product deleted successfully.</response>
    /// <response code="204">No content (if the Product is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Product", Description = "Allows the user to delete a Product by its ID.")]
    [SwaggerResponse(200, "Product deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Product is not found).")]
    public async Task<ActionResult> DeleteProduct([FromRoute] int id)
    {
        if (await ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await ProductServices.Delete(id);
                return Ok("Product deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Product.", dbEX);
            }
        }
    }
}
