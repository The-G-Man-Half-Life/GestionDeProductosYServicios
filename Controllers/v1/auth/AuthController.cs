using GestionDeProductosYServicios.Configurations;
using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace CSharpTest.Controllers.v1.auth;
[ApiController]
[Route("api/v1/auth/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbcontext Context;
    private readonly Utilities Utilities;

    public AuthController(ApplicationDbcontext Context, Utilities Utilities)
    {
        this.Context = Context;
        this.Utilities = Utilities;
    }

        [HttpPost("Login")]
        [SwaggerOperation(
            Summary = "Login into the system",
            Description = "This endpoint allows you to enter the system by using email and password"
        )]
        [SwaggerResponse(200, "Logged in successfully")]
        [SwaggerResponse(401, "Email or password uncorrect")]
        
        public async Task<IActionResult> AuthLogin(ClientLoginDTO ClientLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ClientFound = await Context.Clients.FirstOrDefaultAsync(i => i.Client_id == ClientLogin.id);
            if (ClientFound == null)
            {
                return Unauthorized("id inexistente");
            }

            var passwordvalid = ClientFound.Client_name == Utilities.EncryptpSHA256(ClientLogin.name);

            if (passwordvalid == false)
            {
                return Unauthorized("Contraseña invalida");
            }
            var token = Utilities.GenerateJWTToken(ClientFound);

            return Ok(token);
        }
}