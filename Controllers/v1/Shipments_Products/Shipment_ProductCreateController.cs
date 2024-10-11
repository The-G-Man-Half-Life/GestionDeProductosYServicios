using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipment_Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments_Products")]
public class Shipment_ProductCreateController : Shipment_ProductController
{
    private readonly  Shipment_ProductServices Shipment_ProductServices;

    public Shipment_ProductCreateController(Shipment_ProductServices Shipment_ProductServices) : base(Shipment_ProductServices)
    {
        this.Shipment_ProductServices = Shipment_ProductServices;
    }

    /// <summary>
    /// Creates a new Shipment_Product.
    /// </summary>
    /// <param name="Shipment_ProductDTO">The Shipment_Product DTO that contains the necessary data.</param>
    /// <returns>Returns the newly created Shipment_Product.</returns>
    /// <response code="200">Returns the newly created Shipment_Product.</response>
    /// <response code="400">If the model is null or invalid.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Create a new Shipment_Product", Description = "Allows the user to create a new Shipment_Product.")]
    [SwaggerResponse(200, "Shipment_Product created successfully.", typeof(Shipment_Product))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult<Shipment_Product>> CreateShipment_Product([FromBody] Shipment_ProductDTO Shipment_ProductDTO)
    {
        if (ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (Shipment_ProductDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newShipment_Product = new Shipment_Product
                {
                    Product_amount = Shipment_ProductDTO.Product_amount,
                    Product_id = Shipment_ProductDTO.Product_id,
                    Shipment_id = Shipment_ProductDTO.Shipment_id
                };
                await Shipment_ProductServices.Create(newShipment_Product);
                return Ok(newShipment_Product);
            }
            catch (DbUpdateException dbEX)
            {

                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}