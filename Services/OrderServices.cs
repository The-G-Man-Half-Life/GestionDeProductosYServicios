using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class OrderServices: IOrderRepository
{
    public readonly ApplicationDbcontext Context;

    public OrderServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        try
        {
            return await Context.Orders.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<Order> GetById(int id)
    {
        try
        {
            return await Context.Orders.FirstOrDefaultAsync(C=>C.Order_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Create(Order Order)
    {
        try
        {
            await Context.Orders.AddAsync(Order);
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
            var OrderToDelete = await GetById(id);
            Context.Orders.Remove(OrderToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Order Order)
    {
        try
        {
            Context.Orders.Update(Order);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Orders.AnyAsync(c=>c.Order_id == id);
    }
}