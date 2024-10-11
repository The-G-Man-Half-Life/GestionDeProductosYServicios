using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class Products_Orderservices: IProduct_orderRepository
{
    public readonly ApplicationDbcontext Context;

    public Products_Orderservices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Product_order>> GetAll()
    {
        try
        {
            return await Context.Products_Orders.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<Product_order> GetById(int id)
    {
        try
        {
            return await Context.Products_Orders.FirstOrDefaultAsync(C=>C.Product_order_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Create(Product_order Product_order)
    {
        try
        {
            await Context.Products_Orders.AddAsync(Product_order);
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
            var Product_orderToDelete = await GetById(id);
            Context.Products_Orders.Remove(Product_orderToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Product_order Product_order)
    {
        try
        {
            Context.Products_Orders.Update(Product_order);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Products_Orders.AnyAsync(c=>c.Product_order_id == id);
    }
}