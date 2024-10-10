using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeProductosYServicios.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Clients")]
public class ClientController : ControllerBase
{
    private readonly IClientRepository ClientRepository;

    public ClientController(IClientRepository ClientRepository)
    {
        this.ClientRepository = ClientRepository;
    }
}