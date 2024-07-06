using KuzyaBackend.Models;

namespace KuzyaBackend.Repositories.Interfaces;

public interface IIngredientRepository
{
    IQueryable<Ingredient> GetAll();
    Ingredient? GetByIdAsync(long id);
    Ingredient Create(Ingredient ingredient);
}