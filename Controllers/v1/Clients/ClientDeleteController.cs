using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Clients;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Clients")]
public class ClientDeleteController : ClientController
{
    private readonly ClientServices ClientServices;

    public ClientDeleteController(ClientServices ClientServices) : base(ClientServices)
    {
        this.ClientServices = ClientServices;
    }

    /// <summary>
    /// Deletes a Client by its ID.
    /// </summary>
    /// <param name="id">The ID of the Client to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Client deleted successfully.</response>
    /// <response code="204">No content (if the Client is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Client", Description = "Allows the user to delete a Client by its ID.")]
    [SwaggerResponse(200, "Client deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Client is not found).")]
    public async Task<ActionResult> DeleteClient([FromRoute] int id)
    {
        if (await ClientServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await ClientServices.Delete(id);
                return Ok("Client deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Client.", dbEX);
            }
        }
    }
}
