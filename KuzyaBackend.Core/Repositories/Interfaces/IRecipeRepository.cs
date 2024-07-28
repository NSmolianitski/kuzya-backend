using KuzyaBackend.Models;

namespace KuzyaBackend.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Recipe?> TryGetByIdAsync(long id);
    Task<Recipe> CreateAsync(Recipe recipe);
}