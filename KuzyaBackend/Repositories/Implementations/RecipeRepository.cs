using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;

namespace KuzyaBackend.Repositories.Implementations;

public class RecipeRepository(ApplicationDbContext db) : IRecipeRepository
{
    public IQueryable<Recipe> GetAll()
    {
        return db.Recipes;
    }

    public Recipe? GetByIdAsync(long id)
    {
        return db.Recipes.SingleOrDefault(r => r.Id == id);
    }

    public Recipe Create(Recipe recipe)
    {
        recipe = db.Recipes.Add(recipe).Entity;
        db.SaveChanges();
        return recipe;
    }
}