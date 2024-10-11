using GestionDeProductosYServicios.DTOs.Requests;
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
public class Product_OrderCreateController : Product_OrderController
{
    private readonly Products_Orderservices Products_Orderservices;
    private readonly Shipment_ProductServices Shipment_ProductServices;

    public Product_OrderCreateController(Products_Orderservices Products_Orderservices,Shipment_ProductServices Shipment_ProductServices) : base(Products_Orderservices)
    {
        this.Products_Orderservices = Products_Orderservices;
        this.Shipment_ProductServices = Shipment_ProductServices;

    }

    /// <summary>
    /// Creates a new Product_Order.
    /// </summary>
    /// <param name="Product_OrderDTO">The Product_Order DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Product_Order.</returns>
    /// <response code="200">Returns the newly created Product_Order.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Product_Order", Description = "Allows the user to create a new Product_Order.")]
    [SwaggerResponse(200, "Product_Order created successfully.", typeof(Product_Order))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Product_Order>> CreateProduct_Order([FromBody] Product_OrderDTO Product_OrderDTO)
    {
        var productAmount = await Shipment_ProductServices.GetAll();
        var allShipmentProducts = productAmount.Where(p=>p.Product_id == Product_OrderDTO.Product_id).ToList();
        int totalProduct = allShipmentProducts.Sum(p=>p.Product_amount);


        var spentProducts = await Products_Orderservices.GetAll();
        var AllSentProducts = spentProducts.Where(p=>p.Product_id == Product_OrderDTO.Product_id).ToList();
        int spentProduct = AllSentProducts.Sum(p=>p.Product_quantity);


        int restingProduct = totalProduct-spentProduct;

        if (restingProduct<Product_OrderDTO.Product_quantity)
        {
            return BadRequest("NO queda suficiente producto solo queda " + restingProduct);
        }
        else if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (Product_OrderDTO == null)
        {
            return NoContent();
        }
        
        else
        {
            try
            {
                var newProduct_Order = new Product_Order
                {
                    Product_quantity = Product_OrderDTO.Product_quantity,
                    Product_id = Product_OrderDTO.Product_id,
                    Order_id = Product_OrderDTO.Order_id
                };
                await Products_Orderservices.Create(newProduct_Order);
                return Ok(newProduct_Order);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}