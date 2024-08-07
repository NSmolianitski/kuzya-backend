﻿using KuzyaBackend.Services.Interfaces;
using KuzyaBackend.Web.DTOs.IngredientController;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Web.Controllers;

[ApiController]
[Route("api/v1/ingredients")]
public class IngredientController(IIngredientService ingredientService)
{
    [HttpGet]
    public async Task<IActionResult> GetAllIngredients()
    {
        var ingredients = await ingredientService.GetAllIngredientsAsync();
        return new JsonResult(ingredients);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetIngredientById(long id)
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