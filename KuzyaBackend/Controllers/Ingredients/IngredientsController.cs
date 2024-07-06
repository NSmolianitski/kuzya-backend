using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Controllers;

[ApiController]
[Route("api/v1/ingredients")]
public class IngredientsController(IIngredientService ingredientService)
{
    [HttpGet]
    public IActionResult GetAllIngredients()
    {
        var ingredients = ingredientService.GetAllIngredients();
        return new JsonResult(ingredients);
    }
    
    [HttpPost]
    public IActionResult CreateIngredient([FromBody] CreateIngredientDto createIngredientDto)
    {
        var ingredientDto = ingredientService.CreateIngredient(createIngredientDto);
        return new CreatedResult(nameof(CreateIngredient), ingredientDto);
    }
}