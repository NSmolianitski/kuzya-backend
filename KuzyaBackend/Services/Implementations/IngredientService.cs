using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Controllers.Dto.Responses;
using KuzyaBackend.Models;
using KuzyaBackend.Repositories.Interfaces;
using KuzyaBackend.Services.Interfaces;

namespace KuzyaBackend.Services.Implementations;

public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
{
    public IEnumerable<IngredientDto> GetAllIngredients()
    {
        return ingredientRepository.GetAll().AsEnumerable().Select(MapIngredientToDto);
    }

    public IngredientDto CreateIngredient(CreateIngredientDto createIngredientDto)
    {
        var ingredient = new Ingredient
        {
            Name = createIngredientDto.Name,
            AvatarId = createIngredientDto.AvatarId,
            Calories = createIngredientDto.Calories,
            Proteins = createIngredientDto.Proteins,
            Fats = createIngredientDto.Fats,
            Carbohydrates = createIngredientDto.Carbohydrates
        };

        var createdIngredient = ingredientRepository.Create(ingredient);
        return MapIngredientToDto(createdIngredient);
    }

    private IngredientDto MapIngredientToDto(Ingredient ingredient)
    {
        return new IngredientDto(
            ingredient.Id,
            ingredient.Name,
            ingredient.AvatarId,
            ingredient.Calories,
            ingredient.Proteins,
            ingredient.Fats,
            ingredient.Carbohydrates
        );
    }
}