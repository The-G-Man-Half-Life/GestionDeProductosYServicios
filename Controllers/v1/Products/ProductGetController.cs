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
    private readonly Shipment_ProductServices Shipment_ProductServices;
    private readonly Products_Orderservices Products_Orderservices;

    public ProductGetController(ProductServices ProductServices,Shipment_ProductServices Shipment_ProductServices,Products_Orderservices Products_Orderservices): base(ProductServices)
    {
        this.ProductServices = ProductServices;
        this.Shipment_ProductServices =Shipment_ProductServices;
        this.Products_Orderservices = Products_Orderservices;
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

    /// <summary>
    /// Retrieves all Products by a keyword.
    /// </summary>
    /// <returns>A list of Products by a keyword.</returns>
    /// <response code="200">Returns the list of Products.</response>
    /// <response code="204">No content if no Products are found.</response>
    [HttpGet("/searchbykeyword/{keyword}")]
    [SwaggerOperation(Summary = "Get all Products by keyword", Description = "Retrieves a list of products by a keyword.")]
    [SwaggerResponse(200, "Returns the list of Products.", typeof(IEnumerable<Product>))]
    [SwaggerResponse(204, "No content if no Products are found.")]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsByKeywork([FromRoute]string keyword)
    {
        var Products = await ProductServices.GetAll();
        var FoundElements = Products.Where(p=>p.Product_name.Contains(keyword)|| p.Product_description.Contains(keyword)); 

        if (FoundElements.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(FoundElements);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Products.", dbEX);
            }
        }
    }

    /// <summary>
    /// Retrieves all Products by low amoung.
    /// </summary>
    /// <returns>A list of Products by their low amount of product.</returns>
    /// <response code="200">Returns the list of Products by their low amount.</response>
    /// <response code="204">No content if no Products are found.</response>
    [HttpGet("/lowamountproducts/")]
    [SwaggerOperation(Summary = "Get all Products by their low amount", Description = "Retrieves a list of products by Their low amount")]
    [SwaggerResponse(200, "Returns the list of Products.", typeof(IEnumerable<Product>))]
    [SwaggerResponse(204, "No content if no Products are found.")]
    public async Task<ActionResult<IEnumerable<Product>>> LowAmountProducts()
    {
        var ProductsAmounts = await Shipment_ProductServices.GetAll();
        var ProductsSpent = await Products_Orderservices.GetAll();

        var groupedProductsAmounts = ProductsAmounts.GroupBy(pa => pa.Product_id)
        .Select(g=> new{
            productID = g.Key,
            TotalAmount = g.Sum(pa=>pa.Product_amount)
        });

        var groupedProductsSpent = ProductsSpent.GroupBy(pa=>pa.Product_id)
        .Select(g=> new{
            productId = g.Key,
            TotalQuantity = g.Sum(pa=>pa.Product_quantity)
        });

        var result = groupedProductsAmounts
    .GroupJoin(groupedProductsSpent,
        amount => amount.productID,
        spent => spent.productId,
        (amount, spentGroup) => new
        {
            ProductId = amount.productID,
            TotalAmount = amount.TotalAmount,
            TotalQuantity = spentGroup.FirstOrDefault()?.TotalQuantity ?? 0
        })
    .Select(x => new
    {
        ProductId = x.ProductId,
        LeftAmount = x.TotalAmount - x.TotalQuantity
    })
    .ToList();

    var productsWithLowAmount = result.Where(p=>p.LeftAmount<=5).ToList(); 

        if (productsWithLowAmount.Count() == 0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(productsWithLowAmount);
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error occurred while retrieving Products.", dbEX);
            }
        }
    }
}
