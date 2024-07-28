using KuzyaBackend.Controllers.Recipes.Dto.Requests;
using KuzyaBackend.Controllers.Recipes.Dto.Responses;

namespace KuzyaBackend.Services.Interfaces;

public interface IRecipeService
{
    Task<IEnumerable<RecipeDto>> GetAllRecipesAsync();
    Task<RecipeDto> GetRecipeByIdAsync(long id);
    Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto);
}