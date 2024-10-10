using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierUpdateController : CarrierController
{
    private readonly CarrierServices CarrierServices;
    
    public CarrierUpdateController(CarrierServices CarrierServices): base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    /// <summary>
    /// Updates an existing carrier by its ID.
    /// </summary>
    /// <param name="id">The ID of the carrier to update.</param>
    /// <param name="CarrierDTO">The updated carrier data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Carrier updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the carrier is not found or if CarrierDTO is null).</response>
    /// <response code="404">Carrier not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a carrier", Description = "Allows the user to update a carrier.")]
    [SwaggerResponse(200, "Carrier updated successfully.", typeof(Carrier))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateCarrier([FromRoute]int id,[FromBody]CarrierDTO CarrierDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (CarrierDTO == null)
        {
            return NoContent();
        }
        else if (await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundUser = await CarrierServices.GetById(id);

            foundUser.Carrier_name = CarrierDTO.Carrier_name;
            foundUser.Carrier_description = CarrierDTO.Carrier_description;

            await CarrierServices.Update(foundUser);
            return Ok("Se actualizo exitosamente");
        }
    } 
}