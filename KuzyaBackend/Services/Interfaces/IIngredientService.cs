using Kuzya_Backend.Controllers.Ingredients.Dto.Requests;
using Kuzya_Backend.Controllers.Ingredients.Dto.Responses;

namespace Kuzya_Backend.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync();
    Task<IngredientDto> GetIngredientByIdAsync(long id);
    Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto createIngredientDto);
}