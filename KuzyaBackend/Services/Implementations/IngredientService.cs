﻿using Kuzya_Backend.Controllers.Dto;
using Kuzya_Backend.Controllers.Ingredients.Dto.Requests;
using Kuzya_Backend.Controllers.Ingredients.Dto.Responses;
using Kuzya_Backend.Models;
using Kuzya_Backend.Repositories.Interfaces;
using Kuzya_Backend.Services.Exceptions;
using Kuzya_Backend.Services.Interfaces;

namespace Kuzya_Backend.Services.Implementations;

public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
{
    public async Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync()
    {
        var ingredients = await ingredientRepository.GetAllAsync();
        return ingredients.Select(MapIngredientToDto);
    }
    
    public async Task<IngredientDto> GetIngredientByIdAsync(long id)
    {
        var ingredient = await ingredientRepository.TryGetByIdAsync(id);
        if (ingredient is null)
            throw new NoSuchEntityInDatabaseException($"Ingredient with id {id} doesn't exist");
        
        return MapIngredientToDto(ingredient);
    }
    
    public async Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto createIngredientDto)
    {
        var ingredient = new Ingredient
        {
            Name = createIngredientDto.Name,
            AvatarId = createIngredientDto.AvatarId,
            Calories = createIngredientDto.Nutrients.Calories,
            Proteins = createIngredientDto.Nutrients.Proteins,
            Fats = createIngredientDto.Nutrients.Fats,
            Carbohydrates = createIngredientDto.Nutrients.Carbohydrates
        };

        var createdIngredient = await ingredientRepository.CreateAsync(ingredient);
        return MapIngredientToDto(createdIngredient);
    }

    private static IngredientDto MapIngredientToDto(Ingredient ingredient)
    {
        return new IngredientDto(
            ingredient.Id,
            ingredient.Name,
            ingredient.AvatarId,
            new NutrientsDto(
                ingredient.Calories,
                ingredient.Proteins,
                ingredient.Fats,
                ingredient.Carbohydrates)
        );
    }
}