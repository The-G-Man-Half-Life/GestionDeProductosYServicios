using GestionDeProductosYServicios.DTOs.Requests;
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
public class ClientCreateController : ClientController
{
    private readonly ClientServices ClientServices;

    public ClientCreateController(ClientServices ClientServices) : base(ClientServices)
    {
        this.ClientServices = ClientServices;
    }

    /// <summary>
    /// Creates a new Client.
    /// </summary>
    /// <param name="ClientDTO">The Client DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Client.</returns>
    /// <response code="200">Returns the newly created Client.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Client", Description = "Allows the user to create a new Client.")]
    [SwaggerResponse(200, "Client created successfully.", typeof(Client))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Client>> CreateClient([FromBody] ClientDTO ClientDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ClientDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newClient = new Client
                {
                    Client_name = ClientDTO.Client_name,
                    Client_address = ClientDTO.Client_address,
                    Client_contact = ClientDTO.Client_contact
                };
                await ClientServices.Create(newClient);
                return Ok(newClient);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}