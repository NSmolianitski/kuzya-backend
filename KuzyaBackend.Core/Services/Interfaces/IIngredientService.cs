﻿using KuzyaBackend.Controllers.Ingredients.Dto.Requests;
using KuzyaBackend.Controllers.Ingredients.Dto.Responses;

namespace KuzyaBackend.Services.Interfaces;

public interface IIngredientService
{
    Task<IEnumerable<IngredientDto>> GetAllIngredientsAsync();
    Task<IngredientDto> GetIngredientByIdAsync(long id);
    Task<IngredientDto> CreateIngredientAsync(CreateIngredientDto createIngredientDto);
}