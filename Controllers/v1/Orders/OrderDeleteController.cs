using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Orders")]
public class OrderDeleteController : OrderController
{
    private readonly OrderServices OrderServices;

    public OrderDeleteController(OrderServices OrderServices) : base(OrderServices)
    {
        this.OrderServices = OrderServices;
    }

    /// <summary>
    /// Deletes a Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Order to delete.</param>
    /// <returns>A response indicating the result of the delete operation.</returns>
    /// <response code="200">Order deleted successfully.</response>
    /// <response code="204">No content (if the Order is not found).</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Order", Description = "Allows the user to delete a Order by its ID.")]
    [SwaggerResponse(200, "Order deleted successfully.")]
    [SwaggerResponse(204, "No content (if the Order is not found).")]
    public async Task<ActionResult> DeleteOrder([FromRoute] int id)
    {
        if (await OrderServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await OrderServices.Delete(id);
                return Ok("Order deleted successfully.");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while deleting the Order.", dbEX);
            }
        }
    }
}
