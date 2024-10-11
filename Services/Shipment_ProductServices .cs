using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using GestionDeShipment_ProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class Shipment_ProductServices: IShipment_ProductRepository
{
    public readonly ApplicationDbcontext Context;

    public Shipment_ProductServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Shipment_Product>> GetAll()
    {
        try
        {
            return await Context.Shipment_Products.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<Shipment_Product> GetById(int id)
    {
        try
        {
            return await Context.Shipment_Products.FirstOrDefaultAsync(C=>C.Shipment_Product_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Create(Shipment_Product Shipment_Product)
    {
        try
        {
            await Context.Shipment_Products.AddAsync(Shipment_Product);
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
            var Shipment_ProductToDelete = await GetById(id);
            Context.Shipment_Products.Remove(Shipment_ProductToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Shipment_Product Shipment_Product)
    {
        try
        {
            Context.Shipment_Products.Update(Shipment_Product);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Shipment_Products.AnyAsync(c=>c.Shipment_Product_id == id);
    }
}