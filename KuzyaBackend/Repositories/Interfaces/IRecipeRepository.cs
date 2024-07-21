using Kuzya_Backend.Models;

namespace Kuzya_Backend.Repositories.Interfaces;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task<Recipe?> TryGetByIdAsync(long id);
    Task<Recipe> CreateAsync(Recipe recipe);
}