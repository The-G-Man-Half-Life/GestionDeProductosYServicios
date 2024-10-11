using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Product_Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products_Orders")]
public class Product_OrderDeleteController : Product_OrderController
{
    private readonly Products_Orderservices Products_Orderservices;

    public Product_OrderDeleteController(Products_Orderservices Products_Orderservices) : base(Products_Orderservices)
    {
        this.Products_Orderservices = Products_Orderservices;
    }

    /// <summary>
    /// Deletes a Product_Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product_Order to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Product_Order deleted successfully.</response>
    /// <response code="204">No content (if the Product_Order is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Product_Order", Description = "Allows the user to delete a Product_Order by its ID.")]
    [SwaggerResponse(200, "Product_Order deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Product_Order is not found).")]
    public async Task<ActionResult> DeleteProduct_Order([FromRoute] int id)
    {
        if (await Products_Orderservices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await Products_Orderservices.Delete(id);
                return Ok("Product_Order deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Product_Order.", dbEX);
            }
        }
    }
}
