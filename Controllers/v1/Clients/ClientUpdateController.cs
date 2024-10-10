using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Clients;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Clients")]
public class ClientUpdateController : ClientController
{
    private readonly ClientServices ClientServices;
    
    public ClientUpdateController(ClientServices ClientServices): base(ClientServices)
    {
        this.ClientServices = ClientServices;
    }

    /// <summary>
    /// Updates an existing Client by its ID.
    /// </summary>
    /// <param name="id">The ID of the Client to update.</param>
    /// <param name="ClientDTO">The updated Client data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Client updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Client is not found or if ClientDTO is null).</response>
    /// <response code="404">Client not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Client", Description = "Allows the user to update a Client.")]
    [SwaggerResponse(200, "Client updated successfully.", typeof(Client))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateClient([FromRoute]int id,[FromBody]ClientDTO ClientDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ClientDTO == null)
        {
            return NoContent();
        }
        else if (await ClientServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundUser = await ClientServices.GetById(id);

            foundUser.Client_name = ClientDTO.Client_name;
            foundUser.Client_address = ClientDTO.Client_address;
            foundUser.Client_contact = ClientDTO.Client_contact;

            await ClientServices.Update(foundUser);
            return Ok("Se actualizo exitosamente");
        }
    } 
}