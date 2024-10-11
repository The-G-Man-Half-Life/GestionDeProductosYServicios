using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Orders")]
public class OrderCreateController : OrderController
{
    private readonly OrderServices OrderServices;

    public OrderCreateController(OrderServices OrderServices) : base(OrderServices)
    {
        this.OrderServices = OrderServices;
    }

    /// <summary>
    /// Creates a new Order.
    /// </summary>
    /// <param name="OrderDTO">The Order DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Order.</returns>
    /// <response code="200">Returns the newly created Order.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Order", Description = "Allows the user to create a new Order.")]
    [SwaggerResponse(200, "Order created successfully.", typeof(Order))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDTO OrderDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (OrderDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newOrder = new Order
                {
                    Order_creation_date = OrderDTO.Order_creation_date,
                    Order_delivery_date = OrderDTO.Order_delivery_date,
                    Client_id = OrderDTO.Client_id,
                    Carrier_id = OrderDTO.Carrier_id
                };
                await OrderServices.Create(newOrder);
                return Ok(newOrder);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}