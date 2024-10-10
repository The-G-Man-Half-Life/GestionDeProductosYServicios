using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Clients;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Clients")]
public class ClientGetController : ClientController
{
    private readonly ClientServices ClientServices;

    public ClientGetController(ClientServices ClientServices) : base(ClientServices)
    {
        this.ClientServices = ClientServices;
    }

    /// <summary>
    /// Retrieves all Clients.
    /// </summary>
    /// <returns>A list of Clients.</returns>
    /// <response code="200">Returns the list of Clients.</response>
    /// <response code="204">No content if no Clients are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Clients", Description = "Retrieves a list of all Clients.")]
    [SwaggerResponse(200, "Returns the list of Clients.", typeof(IEnumerable<Client>))]
    [SwaggerResponse(204, "No content if no Clients are found.")]
    public async Task<ActionResult<IEnumerable<Client>>> GetAllClients()
    {
        var Clients = await ClientServices.GetAll();

        if (Clients.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Clients);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Clients.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Client by its ID.
    /// </summary>
    /// <param name="id">The ID of the Client to retrieve.</param>
    /// <returns>The Client with the specified ID.</returns>
    /// <response code="200">Returns the Client.</response>
    /// <response code="204">No content if the Client is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Client by ID", Description = "Retrieves a Client by its ID.")]
    [SwaggerResponse(200, "Returns the Client.", typeof(Client))]
    [SwaggerResponse(204, "No content if the Client is not found.")]
    public async Task<ActionResult<Client>> GetAClientById([FromRoute] int id)
    {
        if (await ClientServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await ClientServices.GetById(id);
        }
    }
}
