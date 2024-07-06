using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;

namespace KuzyaBackend.Repositories.Implementations;

public class IngredientRepository(ApplicationDbContext db) : IIngredientRepository
{
    public IQueryable<Ingredient> GetAll()
    {
        return db.Ingredients;
    }

    public Ingredient? GetByIdAsync(long id)
    {
        return db.Ingredients.SingleOrDefault(i => i.Id == id);
    }

    public Ingredient Create(Ingredient ingredient)
    {
        ingredient = db.Ingredients.Add(ingredient).Entity;
        db.SaveChanges();
        return ingredient;
    }
}