using KuzyaBackend.Controllers.Recipes.Dto.Requests;
using KuzyaBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Controllers.Recipes;

[ApiController]
[Route("api/v1/recipes")]
public class RecipeController(IRecipeService recipeService)
{
    [HttpGet]
    public IActionResult GetAllRecipes()
    {
        var ingredients = recipeService.GetAllRecipes();
        return new JsonResult(ingredients);
    }
    
    [HttpPost]
    public IActionResult CreateRecipe([FromBody] CreateRecipeDto createRecipeDto)
    {
        var ingredientDto = recipeService.CreateRecipe(createRecipeDto);
        return new CreatedResult(nameof(CreateRecipe), ingredientDto);
    }
}