using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products")]
public class ProductGetController : ProductController
{
    private readonly ProductServices ProductServices;

    public ProductGetController(ProductServices ProductServices): base(ProductServices)
    {
        this.ProductServices = ProductServices;
    }

    /// <summary>
    /// Retrieves all Products.
    /// </summary>
    /// <returns>A list of Products.</returns>
    /// <response code="200">Returns the list of Products.</response>
    /// <response code="204">No content if no Products are found.</response>
    [HttpGet]
    [SwaggerOperation(Summary = "Get all Products", Description = "Retrieves a list of all Products.")]
    [SwaggerResponse(200, "Returns the list of Products.", typeof(IEnumerable<Product>))]
    [SwaggerResponse(204, "No content if no Products are found.")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        var Products = await ProductServices.GetAll();

        if (Products.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(Products);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Products.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves a Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product to retrieve.</param>
    /// <returns>The Product with the specified ID.</returns>
    /// <response code="200">Returns the Product.</response>
    /// <response code="204">No content if the Product is not found.</response>
    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Product by ID", Description = "Retrieves a Product by its ID.")]
    [SwaggerResponse(200, "Returns the Product.", typeof(Product))]
    [SwaggerResponse(204, "No content if the Product is not found.")]
    public async Task<ActionResult<Product>> GetAProductById([FromRoute] int id)
    {
        if (await ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await ProductServices.GetById(id);
        }
    }
}
