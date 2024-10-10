using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/Carriers/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierDeleteController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierDeleteController(CarrierServices CarrierServices): base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCarrier([FromRoute] int id)
    {
        if(await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else 
        {
            try
            {
                await CarrierServices.Delete(id);
                return Ok("Se elimino exitosamente");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("Un error ocurrio",dbEX);
            }
        }
    }
}