using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipments;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments")]
public class ShipmentDeleteController : ShipmentController
{
    private readonly ShipmentServices ShipmentServices;

    public ShipmentDeleteController(ShipmentServices ShipmentServices) : base(ShipmentServices)
    {
        this.ShipmentServices = ShipmentServices;
    }

    /// <summary>
    /// Deletes a Shipment by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Shipment deleted successfully.</response>
    /// <response code="204">No content (if the Shipment is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Shipment", Description = "Allows the user to delete a Shipment by its ID.")]
    [SwaggerResponse(200, "Shipment deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Shipment is not found).")]
    public async Task<ActionResult> DeleteShipment([FromRoute] int id)
    {
        if (await ShipmentServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await ShipmentServices.Delete(id);
                return Ok("Shipment deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Shipment.", dbEX);
            }
        }
    }
}
