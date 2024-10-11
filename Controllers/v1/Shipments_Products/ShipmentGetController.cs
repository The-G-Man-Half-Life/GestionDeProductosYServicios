
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipment_Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments_Products")]
public class Shipment_ProductGetController : Shipment_ProductController
{
    private readonly Shipment_ProductServices Shipment_ProductServices;

    public Shipment_ProductGetController(Shipment_ProductServices Shipment_ProductServices) : base(Shipment_ProductServices)
    {
        this.Shipment_ProductServices = Shipment_ProductServices;
    }

    /// <summary>
    /// Retrieves all Shipment_Products.
    /// </summary>
    /// <returns>A list of Shipment_Products.</returns>
    /// <response code="200">Returns the list of Shipment_Products.</response>
    /// <response code="204">No content if no Shipment_Products are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Shipment_Products", Description = "Retrieves a list of all Shipment_Products.")]
    [SwaggerResponse(200, "Returns the list of Shipment_Products.", typeof(IEnumerable<Shipment_Product>))]
    [SwaggerResponse(204, "No content if no Shipment_Products are found.")]
    public async Task<ActionResult<IEnumerable<Shipment_Product>>> GetAllShipment_Products()
    {
        var Shipment_Products = await Shipment_ProductServices.GetAll();

        if (Shipment_Products.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Shipment_Products);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Shipment_Products.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Shipment_Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment_Product to retrieve.</param>
    /// <returns>The Shipment_Product with the specified ID.</returns>
    /// <response code="200">Returns the Shipment_Product.</response>
    /// <response code="204">No content if the Shipment_Product is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Shipment_Product by ID", Description = "Retrieves a Shipment_Product by its ID.")]
    [SwaggerResponse(200, "Returns the Shipment_Product.", typeof(Shipment_Product))]
    [SwaggerResponse(204, "No content if the Shipment_Product is not found.")]
    public async Task<ActionResult<Shipment_Product>> GetAShipment_ProductById([FromRoute] int id)
    {
        if (await Shipment_ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await Shipment_ProductServices.GetById(id);
        }
    }
}
