using Kuzya_Backend.Controllers.Recipes.Dto.Requests;
using Kuzya_Backend.Controllers.Recipes.Dto.Responses;

namespace Kuzya_Backend.Services.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
    Task<RecipeDto> GetRecipeByIdAsync(long id);
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
}