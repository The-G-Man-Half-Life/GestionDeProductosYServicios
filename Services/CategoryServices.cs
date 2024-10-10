using GestionDeProductosYServicios.Data;
using GestionDeProductosYServicios.Models;
using GestionDeProductosYServicios.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestionDeProductosYServicios.Services;
public class CategoryServices:ICategoryRepository
{
    private readonly ApplicationDbcontext Context ;

    public CategoryServices(ApplicationDbcontext Context)
    {
        this.Context = Context;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
        try
        {
            return await Context.Categories.ToListAsync();
        }
        catch (DbUpdateException dbEX)
        {
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }
    public async Task<Category> GetById(int id)
    {
        try
        {
            return await Context.Categories.FirstOrDefaultAsync(c=>c.Category_id == id);
        }
        catch (DbUpdateException dbEX)
        {
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }
    public async Task Create(Category Category)
    {
        try
        {
            await Context.Categories.AddAsync(Category);
            await Context.SaveChangesAsync();
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
            var categoryToErase =await GetById(id);
            Context.Categories.Remove(categoryToErase);
        }
        catch (DbUpdateException dbEX)
        {
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }
    public async Task Update(Category Category)
    {
        try
        {
            Context.Categories.Update(Category);
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException dbEX)
        {
            throw new DbUpdateException("Un error ocurrio",dbEX);
        }
    }
    public async Task<bool> CheckExistence(int id)
    {
        return await Context.Categories.AnyAsync(c=>c.Category_id == id);
    }
}