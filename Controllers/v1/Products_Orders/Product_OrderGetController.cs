using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Product_Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products_Orders")]
public class Product_OrderGetController : Product_OrderController
{
    private readonly Products_Orderservices Products_Orderservices;

    public Product_OrderGetController(Products_Orderservices Products_Orderservices) : base(Products_Orderservices)
    {
        this.Products_Orderservices = Products_Orderservices;
    }

    /// <summary>
    /// Retrieves all Product_Orders.
    /// </summary>
    /// <returns>A list of Product_Orders.</returns>
    /// <response code="200">Returns the list of Product_Orders.</response>
    /// <response code="204">No content if no Product_Orders are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Product_Orders", Description = "Retrieves a list of all Product_Orders.")]
    [SwaggerResponse(200, "Returns the list of Product_Orders.", typeof(IEnumerable<Product_Order>))]
    [SwaggerResponse(204, "No content if no Product_Orders are found.")]
    public async Task<ActionResult<IEnumerable<Product_Order>>> GetAllProduct_Orders()
    {
        var Product_Orders = await Products_Orderservices.GetAll();

        if (Product_Orders.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Product_Orders);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Product_Orders.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Product_Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product_Order to retrieve.</param>
    /// <returns>The Product_Order with the specified ID.</returns>
    /// <response code="200">Returns the Product_Order.</response>
    /// <response code="204">No content if the Product_Order is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Product_Order by ID", Description = "Retrieves a Product_Order by its ID.")]
    [SwaggerResponse(200, "Returns the Product_Order.", typeof(Product_Order))]
    [SwaggerResponse(204, "No content if the Product_Order is not found.")]
    public async Task<ActionResult<Product_Order>> GetAProduct_OrderById([FromRoute] int id)
    {
        if (await Products_Orderservices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await Products_Orderservices.GetById(id);
        }
    }
}
