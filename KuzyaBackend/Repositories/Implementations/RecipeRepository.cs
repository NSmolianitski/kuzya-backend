using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend.Repositories.Implementations;

public class RecipeRepository(ApplicationDbContext db) : IRecipeRepository
{
    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return await db.Recipes.ToListAsync();
    }

    public async Task<Recipe?> TryGetByIdAsync(long id)
    {
        return await db.Recipes.SingleOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Recipe> CreateAsync(Recipe recipe)
    {
        recipe = db.Recipes.Add(recipe).Entity;
        await db.SaveChangesAsync();
        return recipe;
    }
}