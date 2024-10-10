using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/Carriers/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierUpdateController : CarrierController
{
    private readonly CarrierServices CarrierServices;
    
    public CarrierUpdateController(CarrierServices CarrierServices): base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCarrier([FromRoute]int id,[FromBody]CarrierDTO CarrierDTO)
    {
        if(ModelState.IsValid == false)
        {
            return BadRequest();
        }
        else if (CarrierDTO == null)
        {
            return NoContent();
        }
        else if (await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            var foundUser = await CarrierServices.GetById(id);

            foundUser.Carrier_name = CarrierDTO.Carrier_name;
            foundUser.Carrier_description = CarrierDTO.Carrier_description;

            await CarrierServices.Update(foundUser);
            return Ok("Se actualizo exitosamente");
        }
    } 
}