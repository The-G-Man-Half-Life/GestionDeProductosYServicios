using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
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