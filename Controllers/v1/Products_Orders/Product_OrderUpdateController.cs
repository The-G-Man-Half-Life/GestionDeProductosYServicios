using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Product_Orders;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Products_Orders")]
public class Product_OrderUpdateController : Product_OrderController
{
    private readonly Products_Orderservices Products_Orderservices;
    private readonly Shipment_ProductServices Shipment_ProductServices;
    
    public Product_OrderUpdateController(Products_Orderservices Products_Orderservices,Shipment_ProductServices Shipment_ProductServices): base(Products_Orderservices)
    {
        this.Products_Orderservices = Products_Orderservices;
        this.Shipment_ProductServices = Shipment_ProductServices;
    }

    /// <summary>
    /// Updates an existing Product_Order by its ID.
    /// </summary>
    /// <param name="id">The ID of the Product_Order to update.</param>
    /// <param name="Product_OrderDTO">The updated Product_Order data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Product_Order updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Product_Order is not found or if Product_OrderDTO is null).</response>
    /// <response code="404">Product_Order not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Product_Order", Description = "Allows the user to update a Product_Order.")]
    [SwaggerResponse(200, "Product_Order updated successfully.", typeof(Product_Order))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateProduct_Order([FromRoute]int id,[FromBody]Product_OrderDTO Product_OrderDTO)
    {
        var productAmount = await Shipment_ProductServices.GetAll();
        var allShipmentProducts = productAmount.Where(p=>p.Product_id == Product_OrderDTO.Product_id).ToList();
        int totalProduct = allShipmentProducts.Sum(p=>p.Product_amount);

        var spentProducts = await Products_Orderservices.GetAll();
        var AllSentProducts = productAmount.Where(p=>p.Product_id == Product_OrderDTO.Product_id).ToList();
        int spentProduct = AllSentProducts.Sum(p=>p.Product_amount);

        int restingProduct = totalProduct-spentProduct;
        if (restingProduct<Product_OrderDTO.Product_quantity)
        {
            return BadRequest("NO queda suficiente producto solo queda " + restingProduct);
        }
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (Product_OrderDTO == null)
        {
            return NoContent();
        }
        else if (await Products_Orderservices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundProduct_Order = await Products_Orderservices.GetById(id);

            foundProduct_Order.Product_quantity = Product_OrderDTO.Product_quantity;
            foundProduct_Order.Product_id = Product_OrderDTO.Product_id;
            foundProduct_Order.Order_id = Product_OrderDTO.Order_id;

            await Products_Orderservices.Update(foundProduct_Order);
            return Ok("Se actualizo exitosamente");
        }
    } 
}