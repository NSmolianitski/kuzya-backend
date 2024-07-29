using KuzyaBackend.DataAccess.Models;

namespace KuzyaBackend.DataAccess.Interfaces;

public interface IMealListRepository
{
    Task<IEnumerable<MealList>> GetAllAsync();
    Task<MealList?> TryGetByIdAsync(long id);
    Task<MealList> CreateAsync(MealList ingredient);
}