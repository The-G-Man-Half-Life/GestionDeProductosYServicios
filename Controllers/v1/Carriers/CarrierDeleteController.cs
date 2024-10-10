using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierDeleteController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierDeleteController(CarrierServices CarrierServices) : base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    /// <summary>
    /// Deletes a carrier by its ID.
    /// </summary>
    /// <param name="id">The ID of the carrier to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Carrier deleted successfully.</response>
    /// <response code="204">No content (if the carrier is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a carrier", Description = "Allows the user to delete a carrier by its ID.")]
    [SwaggerResponse(200, "Carrier deleted successfully.")]
    [SwaggerResponse(204, "No content (if the carrier is not found).")]
    public async Task<ActionResult> DeleteCarrier([FromRoute] int id)
    {
        if (await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await CarrierServices.Delete(id);
                return Ok("Carrier deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the carrier.", dbEX);
            }
        }
    }
}
