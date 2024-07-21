using KuzyaBackend.Models;

namespace KuzyaBackend.Repositories.Interfaces;

public interface IRecipeRepository
{
    IQueryable<Recipe> GetAll();
    Recipe? GetByIdAsync(long id);
    Recipe Create(Recipe recipe);
}