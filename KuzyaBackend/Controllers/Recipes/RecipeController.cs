﻿using KuzyaBackend.Controllers.Recipes.Dto.Requests;
using KuzyaBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Controllers.Recipes;

[ApiController]
[Route("api/v1/recipes")]
public class RecipeController(IRecipeService recipeService)
{
    [HttpGet]
    public async Task<IActionResult> GetAllRecipes()
    {
        var ingredients = await recipeService.GetAllRecipesAsync();
        return new JsonResult(ingredients);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetRecipeById(long id)
    {
        var ingredient = await recipeService.GetRecipeByIdAsync(id);
        return new JsonResult(ingredient);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeDto createRecipeDto)
    {
        var ingredientDto = await recipeService.CreateRecipeAsync(createRecipeDto);
        return new CreatedResult(nameof(CreateRecipe), ingredientDto);
    }
}