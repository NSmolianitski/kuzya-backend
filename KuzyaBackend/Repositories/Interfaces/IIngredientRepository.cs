using Kuzya_Backend.Models;

namespace Kuzya_Backend.Repositories.Interfaces;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetAllAsync();
    Task<Ingredient?> TryGetByIdAsync(long id);
    Task<Ingredient> CreateAsync(Ingredient ingredient);
}