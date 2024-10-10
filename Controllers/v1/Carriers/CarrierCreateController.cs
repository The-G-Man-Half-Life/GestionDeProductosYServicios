using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierCreateController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierCreateController(CarrierServices CarrierServices) : base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    /// <summary>
    /// Creates a new carrier.
    /// </summary>
    /// <param name="CarrierDTO">The carrier DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created carrier.</returns>
    /// <response code="200">Returns the newly created carrier.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new carrier", Description = "Allows the user to create a new carrier.")]
    [SwaggerResponse(200, "Carrier created successfully.", typeof(Carrier))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Carrier>> CreateCarrier([FromBody] CarrierDTO CarrierDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (CarrierDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newCarrier = new Carrier
                {
                    Carrier_name = CarrierDTO.Carrier_name,
                    Carrier_description = CarrierDTO.Carrier_description
                };
                await CarrierServices.Create(newCarrier);
                return Ok(newCarrier);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}