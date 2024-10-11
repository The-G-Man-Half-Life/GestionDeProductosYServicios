using GestionDeProductosYServicios.DTOs.Requests;
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
public class ProductCreateController : ProductController
{
    private readonly ProductServices ProductServices;

    public ProductCreateController(ProductServices ProductServices) : base(ProductServices)
    {
        this.ProductServices = ProductServices;
    }

    /// <summary>
    /// Creates a new Product.
    /// </summary>
    /// <param name="ProductDTO">The Product DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Product.</returns>
    /// <response code="200">Returns the newly created Product.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Product", Description = "Allows the user to create a new Product.")]
    [SwaggerResponse(200, "Product created successfully.", typeof(Product))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDTO ProductDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (ProductDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newProduct = new Product
                {
                    Product_name = ProductDTO.Product_name,
                    Product_price = ProductDTO.Product_price,
                    Product_description = ProductDTO.Product_description,
                    Category_id = ProductDTO.Category_id
                };
                await ProductServices.Create(newProduct);
                return Ok(newProduct);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}