using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Shipment_Products;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Shipments_Products")]
public class Shipment_ProductUpdateController : Shipment_ProductController
{
    private readonly Shipment_ProductServices Shipment_ProductServices;
    
    public Shipment_ProductUpdateController(Shipment_ProductServices Shipment_ProductServices): base(Shipment_ProductServices)
    {
        this.Shipment_ProductServices = Shipment_ProductServices;
    }

    /// <summary>
    /// Updates an existing Shipment_Product by its ID.
    /// </summary>
    /// <param name="id">The ID of the Shipment_Product to update.</param>
    /// <param name="Shipment_ProductDTO">The updated Shipment_Product data.</param>
    /// <returns>A response indicating the result of the update operation.</returns>
    /// <response code="200">Shipment_Product updated successfully.</response>
    /// <response code="400">Invalid model state.</response>
    /// <response code="204">No content (if the Shipment_Product is not found or if Shipment_ProductDTO is null).</response>
    /// <response code="404">Shipment_Product not found.</response>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "updates a Shipment_Product", Description = "Allows the user to update a Shipment_Product.")]
    [SwaggerResponse(200, "Shipment_Product updated successfully.", typeof(Shipment_Product))]
    [SwaggerResponse(400, "The model cannot be null or is invalid.")]

    public async Task<ActionResult> UpdateShipment_Product([FromRoute]int id,[FromBody]Shipment_ProductDTO Shipment_ProductDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (Shipment_ProductDTO == null)
        {
            return NoContent();
        }
        else if (await Shipment_ProductServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundShipment_Product = await Shipment_ProductServices.GetById(id);

            foundShipment_Product.Product_amount = Shipment_ProductDTO.Product_amount;
            foundShipment_Product.Product_id = Shipment_ProductDTO.Product_id;
            foundShipment_Product.Shipment_id = Shipment_ProductDTO.Shipment_id;

            await Shipment_ProductServices.Update(foundShipment_Product);
            return Ok("Se actualizo exitosamente");
        }
    } 
}