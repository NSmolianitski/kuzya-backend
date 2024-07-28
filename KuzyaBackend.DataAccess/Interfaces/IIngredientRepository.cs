using KuzyaBackend.DataAccess.Models;

namespace KuzyaBackend.DataAccess.Interfaces;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetAllAsync();
    Task<Ingredient?> TryGetByIdAsync(long id);
    Task<Ingredient> CreateAsync(Ingredient ingredient);
}