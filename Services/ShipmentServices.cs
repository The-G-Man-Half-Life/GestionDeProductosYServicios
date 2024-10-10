using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class ShipmentServices: IShipmentRepository
{
    public readonly ApplicationDbcontext Context;

    public ShipmentServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Shipment>> GetAll()
    {
        try
        {
            return await Context.Shipments.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<Shipment> GetById(int id)
    {
        try
        {
            return await Context.Shipments.FirstOrDefaultAsync(C=>C.Shipment_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Create(Shipment Shipment)
    {
        try
        {
            await Context.Shipments.AddAsync(Shipment);
            await Context.SaveChangesAsync();
            
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Delete(int id)
    {
        try
        {
            var ShipmentToDelete = await GetById(id);
            Context.Shipments.Remove(ShipmentToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Shipment Shipment)
    {
        try
        {
            Context.Shipments.Update(Shipment);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Shipments.AnyAsync(c=>c.Shipment_id == id);
    }
}