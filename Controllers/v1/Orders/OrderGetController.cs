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
public class OrderGetController : OrderController
{
    private readonly OrderServices OrderServices;

    public OrderGetController(OrderServices OrderServices) : base(OrderServices)
    {
        this.OrderServices = OrderServices;
    }

    /// <summary>
    /// Retrieves all Orders.
    /// </summary>
    /// <returns>A list of Orders.</returns>
    /// <response code="200">Returns the list of Orders.</response>
    /// <response code="204">No content if no Orders are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Orders", Description = "Retrieves a list of all Orders.")]
    [SwaggerResponse(200, "Returns the list of Orders.", typeof(IEnumerable<Order>))]
    [SwaggerResponse(204, "No content if no Orders are found.")]
    public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
    {
        var Orders = await OrderServices.GetAll();

        if (Orders.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Orders);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Orders.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Order to retrieve.</param>
    /// <returns>The Order with the specified ID.</returns>
    /// <response code="200">Returns the Order.</response>
    /// <response code="204">No content if the Order is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Order by ID", Description = "Retrieves a Order by its ID.")]
    [SwaggerResponse(200, "Returns the Order.", typeof(Order))]
    [SwaggerResponse(204, "No content if the Order is not found.")]
    public async Task<ActionResult<Order>> GetAOrderById([FromRoute] int id)
    {
        if (await OrderServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await OrderServices.GetById(id);
        }
    }


    /// <summary>
    /// Retrieves all Orders From a specific date.
    /// </summary>
    /// <returns>A list of Orders.</returns>
    /// <response code="200">Returns the list of Orders.</response>
    /// <response code="204">No content if no Orders are found.</response>
    [HttpGet("/getdate/{date}")]
    [SwaggerOperation(Summary = "Get all Orders of a date", Description = "Retrieves a list of all Orders.")]
    [SwaggerResponse(200, "Returns the list of Orders.", typeof(IEnumerable<Order>))]
    [SwaggerResponse(204, "No content if no Orders are found.")]
    public async Task<ActionResult<IEnumerable<Object>>> GetAllOrders([FromRoute]DateOnly? date)
    {
        var Orders = await OrderServices.GetAll();
        var OrdersByADate = Orders.Where(o=>o.Order_creation_date == date).ToList();

        if (OrdersByADate.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(OrdersByADate);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Orders.", dbEX);
            }
        }
    }
}
