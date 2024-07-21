using KuzyaBackend.Controllers.Recipes.Dto;
using KuzyaBackend.Controllers.Recipes.Dto.Requests;
using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;
using KuzyaBackend.Services.Interfaces;

namespace KuzyaBackend.Services.Implementations;

public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
{
    public IEnumerable<RecipeDto> GetAllRecipes()
    {
        return recipeRepository.GetAll().AsEnumerable().Select(MapRecipeToDto);
    }

    public RecipeDto CreateRecipe(CreateRecipeDto createRecipeDto)
    {
        var recipe = new Recipe(); // TODO: implement
        
        var createdRecipe = recipeRepository.Create(recipe);
        return MapRecipeToDto(createdRecipe);
    }
    
    private RecipeDto MapRecipeToDto(Recipe recipe)
    {
        return new RecipeDto(); // TODO: implement
    }
}