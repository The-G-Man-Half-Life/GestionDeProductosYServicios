using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipments;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments")]
public class ShipmentUpdateController : ShipmentController
{
    private readonly ShipmentServices ShipmentServices;
    
    public ShipmentUpdateController(ShipmentServices ShipmentServices): base(ShipmentServices)
    {
        this.ShipmentServices = ShipmentServices;
    }

    /// <summary>
    /// Updates an existing Shipment by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment to update.</param>
    /// <param name="ShipmentDTO">The updated Shipment data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Shipment updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Shipment is not found or if ShipmentDTO is null).</response>
    /// <response code="404">Shipment not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Shipment", Description = "Allows the user to update a Shipment.")]
    [SwaggerResponse(200, "Shipment updated successfully.", typeof(Shipment))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateShipment([FromRoute]int id,[FromBody]ShipmentDTO ShipmentDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ShipmentDTO == null)
        {
            return NoContent();
        }
        else if (await ShipmentServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundShipment = await ShipmentServices.GetById(id);

            foundShipment.Shipment_weight_kg = ShipmentDTO.Shipment_weight_kg;
            foundShipment.Shipment_price_usa = ShipmentDTO.Shipment_price_usa;
            foundShipment.Shipment_order_date = ShipmentDTO.Shipment_order_date;
            foundShipment.Shipment_arrival_date = ShipmentDTO.Shipment_arrival_date;
            foundShipment.Carrier_id = ShipmentDTO.Carrier_id;

            await ShipmentServices.Update(foundShipment);
            return Ok("Se actualizo exitosamente");
        }
    } 
}