using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Controllers.v1.Carriers;

[ApiController]
[Route("api/v1/Carriers/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Carriers")]
public class CarrierGetController : CarrierController
{
    private readonly CarrierServices CarrierServices;

    public CarrierGetController(CarrierServices CarrierServices): base(CarrierServices)
    {
        this.CarrierServices = CarrierServices;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carrier>>> GetAllCarriers()
    {
        var carriers = await CarrierServices.GetAll();

        if(carriers.Count()==0)
        {
            return NoContent();
        }
        else
        {
            try
            {
                return Ok(carriers);
            }
            catch (DbUpdateException dbEX)
            {
                
                throw new DbUpdateException("A new exception occurred",dbEX);
            }
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Carrier>> GetACarrierById([FromRoute] int id)
    {
        if(await CarrierServices.CheckExistence(id) == false)
        {
            return NoContent();
        }
        else
        {
            return await CarrierServices.GetById(id);
        }
    }
}