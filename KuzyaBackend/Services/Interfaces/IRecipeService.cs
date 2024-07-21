using KuzyaBackend.Controllers.Recipes.Dto;
using KuzyaBackend.Controllers.Recipes.Dto.Requests;

namespace KuzyaBackend.Services.Interfaces;

public interface IRecipeService
{
    IEnumerable<RecipeDto> GetAllRecipes();
    RecipeDto CreateRecipe(CreateRecipeDto createRecipeDto);
}