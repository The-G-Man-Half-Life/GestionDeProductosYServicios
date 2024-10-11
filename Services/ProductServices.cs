using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.DTOs.Requests;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class ProductServices: IProductRepository
{
    public readonly ApplicationDbcontext Context;

    public ProductServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        try
        {
            return await Context.Products.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<Product> GetById(int id)
    {
        try
        {
            return await Context.Products.FirstOrDefaultAsync(C=>C.Product_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Create(Product Product)
    {
        try
        {
            await Context.Products.AddAsync(Product);
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
            var ProductToDelete = await GetById(id);
            Context.Products.Remove(ProductToDelete);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task Update(Product Product)
    {
        try
        {
            Context.Products.Update(Product);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            
            throw new DbUpdateException("un error ocurrio", dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Products.AnyAsync(c=>c.Product_id == id);
    }
}