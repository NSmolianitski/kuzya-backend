using KuzyaBackend.Controllers.Recipes.Dto;
using KuzyaBackend.Controllers.Recipes.Dto.Requests;
using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;
using KuzyaBackend.Services.Interfaces;

namespace KuzyaBackend.Services.Implementations;

public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
{
    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
    {
        var recipes = await recipeRepository.GetAllAsync();
        return recipes.Select(MapRecipeToDto);
    }

    public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        var recipe = new Recipe(); // TODO: implement

        var createdRecipe = await recipeRepository.CreateAsync(recipe);
        return MapRecipeToDto(createdRecipe);
    }

    private RecipeDto MapRecipeToDto(Recipe recipe)
    {
        return new RecipeDto(); // TODO: implement
    }
}