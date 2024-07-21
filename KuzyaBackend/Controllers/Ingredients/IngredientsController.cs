using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Controllers;

[ApiController]
[Route("api/v1/ingredients")]
public class IngredientsController(IIngredientService ingredientService)
{
    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var ingredients = await ingredientService.GetAllIngredientsAsync();
        return new JsonResult(ingredients);
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredientById(int id)
    {
        var ingredient = await ingredientService.GetIngredientByIdAsync(id);
        return new JsonResult(ingredient);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientDto createIngredientDto)
    {
        var ingredientDto = await ingredientService.CreateIngredientAsync(createIngredientDto);
        return new CreatedResult(nameof(CreateIngredient), ingredientDto);
    }
}