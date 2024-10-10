using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/Carriers/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierCreateController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierCreateController(CarrierServices CarrierServices): base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    /// <summary>
    /// Crea un nuevo transportador.
    /// </summary>
    /// <param name="CarrierDTO">El DTO del transportador que contiene los datos necesarios.</param>
    /// <returns>Devuelve el nuevo transportador creado.</returns>
    /// <response code="200">Devuelve el nuevo transportador creado.</response>
    /// <response code="400">Si el modelo es nulo o inválido.</response>
    [HttpPost]
    [SwaggerOperation(Summary = "Crea un nuevo transportador", Description = "Permite al usuario crear un nuevo transportador.")]
    [SwaggerResponse(200, "Transportador creado exitosame", typeof(Carrier))]
    [SwaggerResponse(400, "El modelo no puede ser nulo o es inválido.")]
    public async Task<ActionResult<Carrier>> CreateCarrier([FromBody] CarrierDTO CarrierDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (CarrierDTO == null)
        {
            return NoContent();
        }
        else
        {
            try
            {
                var newCarrier = new Carrier{
                    Carrier_name = CarrierDTO.Carrier_name,
                    Carrier_description = CarrierDTO.Carrier_description
                };
                await CarrierServices.Create(newCarrier);
                return Ok(newCarrier);
            }
            catch (DbUpdateException dbEX)
            {
                
                throw new DbUpdateException("Un error ocurrio durante el proceso", dbEX);
            }
        }
    }
}