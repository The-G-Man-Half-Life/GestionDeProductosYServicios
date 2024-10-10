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
public class CarrierGetController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierGetController(CarrierServices CarrierServices) : base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    /// <summary>
    /// Retrieves all carriers.
    /// </summary>
    /// <returns>A list of carriers.</returns>
    /// <response code="200">Returns the list of carriers.</response>
    /// <response code="204">No content if no carriers are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all carriers", Description = "Retrieves a list of all carriers.")]
    [SwaggerResponse(200, "Returns the list of carriers.", typeof(IEnumerable<Carrier>))]
    [SwaggerResponse(204, "No content if no carriers are found.")]
    public async Task<ActionResult<IEnumerable<Carrier>>> GetAllCarriers()
    {
        var carriers = await CarrierServices.GetAll();

        if (carriers.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(carriers);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving carriers.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a carrier by its ID.
    /// </summary>
    /// <param name="id">The ID of the carrier to retrieve.</param>
    /// <returns>The carrier with the specified ID.</returns>
    /// <response code="200">Returns the carrier.</response>
    /// <response code="204">No content if the carrier is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a carrier by ID", Description = "Retrieves a carrier by its ID.")]
    [SwaggerResponse(200, "Returns the carrier.", typeof(Carrier))]
    [SwaggerResponse(204, "No content if the carrier is not found.")]
    public async Task<ActionResult<Carrier>> GetACarrierById([FromRoute] int id)
    {
        if (await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await CarrierServices.GetById(id);
        }
    }
}
