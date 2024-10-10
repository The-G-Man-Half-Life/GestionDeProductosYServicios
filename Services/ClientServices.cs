using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class ClientServices: IClientRepository
{
    private readonly ApplicationDbcontext Context;

    public ClientServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Client>> GetAll()
    {
        try
        {
            return await Context.Clients.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }

    public async Task<Client> GetById(int id)
    {
        try
        {
            return await Context.Clients.FirstOrDefaultAsync(c=>c.Client_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }

    public async Task Create(Client Client)
    {
        try
        {
            await Context.Clients.AddAsync(Client);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }

    public async Task Delete(int id)
    {
        try
        {
            var clientToDelete = await GetById(id);
            Context.Clients.Remove(clientToDelete);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }

    public async Task Update(Client Client)
    {
        try
        {
            Context.Clients.Update(Client);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }

    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Clients.AnyAsync(c=>c.Client_id == id);
    }

}