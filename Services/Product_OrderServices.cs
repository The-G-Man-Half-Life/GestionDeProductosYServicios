using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class Products_Orderservices: IProduct_OrderRepository
{
    public readonly ApplicationDbcontext Context;

    public Products_Orderservices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Product_Order>> GetAll()
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
    public async Task<Product_Order> GetById(int id)
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
    public async Task Create(Product_Order Product_Order)
    {
        try
        {
            await Context.Products_Orders.AddAsync(Product_Order);
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
            var Product_OrderToDelete = await GetById(id);
            Context.Products_Orders.Remove(Product_OrderToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Product_Order Product_Order)
    {
        try
        {
            Context.Products_Orders.Update(Product_Order);
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