using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Controllers.Dto.Responses;

namespace KuzyaBackend.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync();
    Task<IngredientDto> GetIngredientByIdAsync(long id);
    Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto createIngredientDto);
}