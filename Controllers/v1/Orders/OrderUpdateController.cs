using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Orders")]
public class OrderUpdateController : OrderController
{
    private readonly OrderServices OrderServices;
    
    public OrderUpdateController(OrderServices OrderServices): base(OrderServices)
    {
        this.OrderServices = OrderServices;
    }

    /// <summary>
    /// Updates an existing Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Order to update.</param>
    /// <param name="OrderDTO">The updated Order data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Order updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Order is not found or if OrderDTO is null).</response>
    /// <response code="404">Order not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Order", Description = "Allows the user to update a Order.")]
    [SwaggerResponse(200, "Order updated successfully.", typeof(Order))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateOrder([FromRoute]int id,[FromBody]OrderDTO OrderDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (OrderDTO == null)
        {
            return NoContent();
        }
        else if (await OrderServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundOrder = await OrderServices.GetById(id);

            foundOrder.Order_creation_date = OrderDTO.Order_creation_date;
            foundOrder.Order_delivery_date = OrderDTO.Order_delivery_date;
            foundOrder.Client_id = OrderDTO.Client_id; 
            foundOrder.Carrier_id = OrderDTO.Carrier_id;

            await OrderServices.Update(foundOrder);
            return Ok("Se actualizo exitosamente");
        }
    } 
}