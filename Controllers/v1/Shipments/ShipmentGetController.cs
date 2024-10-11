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
public class ShipmentGetController : ShipmentController
{
    private readonly ShipmentServices ShipmentServices;

    public ShipmentGetController(ShipmentServices ShipmentServices) : base(ShipmentServices)
    {
        this.ShipmentServices = ShipmentServices;
    }

    /// <summary>
    /// Retrieves all Shipments.
    /// </summary>
    /// <returns>A list of Shipments.</returns>
    /// <response code="200">Returns the list of Shipments.</response>
    /// <response code="204">No content if no Shipments are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Shipments", Description = "Retrieves a list of all Shipments.")]
    [SwaggerResponse(200, "Returns the list of Shipments.", typeof(IEnumerable<Shipment>))]
    [SwaggerResponse(204, "No content if no Shipments are found.")]
    public async Task<ActionResult<IEnumerable<Shipment>>> GetAllShipments()
    {
        var Shipments = await ShipmentServices.GetAll();

        if (Shipments.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Shipments);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Shipments.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Shipment by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment to retrieve.</param>
    /// <returns>The Shipment with the specified ID.</returns>
    /// <response code="200">Returns the Shipment.</response>
    /// <response code="204">No content if the Shipment is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Shipment by ID", Description = "Retrieves a Shipment by its ID.")]
    [SwaggerResponse(200, "Returns the Shipment.", typeof(Shipment))]
    [SwaggerResponse(204, "No content if the Shipment is not found.")]
    public async Task<ActionResult<Shipment>> GetAShipmentById([FromRoute] int id)
    {
        if (await ShipmentServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await ShipmentServices.GetById(id);
        }
    }
}
