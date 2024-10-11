using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipments;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments")]
public class ShipmentCreateController : ShipmentController
{
    private readonly ShipmentServices ShipmentServices;

    public ShipmentCreateController(ShipmentServices ShipmentServices) : base(ShipmentServices)
    {
        this.ShipmentServices = ShipmentServices;
    }

    /// <summary>
    /// Creates a new Shipment.
    /// </summary>
    /// <param name="ShipmentDTO">The Shipment DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Shipment.</returns>
    /// <response code="200">Returns the newly created Shipment.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Shipment", Description = "Allows the user to create a new Shipment.")]
    [SwaggerResponse(200, "Shipment created successfully.", typeof(Shipment))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Shipment>> CreateShipment([FromBody] ShipmentDTO ShipmentDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ShipmentDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newShipment = new Shipment
                {
                    Shipment_weight_kg = ShipmentDTO.Shipment_weight_kg,
                    Shipment_price_usa = ShipmentDTO.Shipment_price_usa,
                    Shipment_order_date = ShipmentDTO.Shipment_order_date,
                    Shipment_arrival_date = ShipmentDTO.Shipment_arrival_date,
                    Carrier_id = ShipmentDTO.Carrier_id
                };
                await ShipmentServices.Create(newShipment);
                return Ok(newShipment);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}