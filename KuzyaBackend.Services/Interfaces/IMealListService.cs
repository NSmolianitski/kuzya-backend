using KuzyaBackend.Web.DTOs.MealListController;

namespace KuzyaBackend.Services.Interfaces;

public interface IMealListService
{
    Task<IEnumerable<MealListDto>> GetAllMealListsAsync();
    Task<MealListDto> GetMealListByIdAsync(long id);
    Task<MealListDto> CreateMealListAsync(CreateMealListDto createMealListDto);
}