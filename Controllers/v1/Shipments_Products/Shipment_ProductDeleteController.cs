using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipment_Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments_Products")]
public class Shipment_ProductDeleteController : Shipment_ProductController
{
    private readonly Shipment_ProductServices Shipment_ProductServices;

    public Shipment_ProductDeleteController(Shipment_ProductServices Shipment_ProductServices) : base(Shipment_ProductServices)
    {
        this.Shipment_ProductServices = Shipment_ProductServices;
    }

    /// <summary>
    /// Deletes a Shipment_Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment_Product to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Shipment_Product deleted successfully.</response>
    /// <response code="204">No content (if the Shipment_Product is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Shipment_Product", Description = "Allows the user to delete a Shipment_Product by its ID.")]
    [SwaggerResponse(200, "Shipment_Product deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Shipment_Product is not found).")]
    public async Task<ActionResult> DeleteShipment_Product([FromRoute] int id)
    {
        if (await Shipment_ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await Shipment_ProductServices.Delete(id);
                return Ok("Shipment_Product deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Shipment_Product.", dbEX);
            }
        }
    }
}
