using Kuzya_Backend.Controllers.Dto;
using Kuzya_Backend.Controllers.Recipes.Dto;
using Kuzya_Backend.Controllers.Recipes.Dto.Requests;
using Kuzya_Backend.Controllers.Recipes.Dto.Responses;
using Kuzya_Backend.Models;
using Kuzya_Backend.Repositories.Interfaces;
using Kuzya_Backend.Services.Exceptions;
using Kuzya_Backend.Services.Interfaces;

namespace Kuzya_Backend.Services.Implementations;

public class RecipeService(IRecipeRepository recipeRepository) : IRecipeService
{
    public async Task<IEnumerable<RecipeDto>> GetAllRecipesAsync()
    {
        var recipes = await recipeRepository.GetAllAsync();
        return recipes.Select(MapRecipeToDto);
    }

    public async Task<RecipeDto> GetRecipeByIdAsync(long id)
    {
        var recipe = await recipeRepository.TryGetByIdAsync(id);
        if (recipe is null)
            throw new NoSuchEntityInDatabaseException($"Recipe with id {id} doesn't exist");

        return MapRecipeToDto(recipe);
    }

    public async Task<RecipeDto> CreateRecipeAsync(CreateRecipeDto createRecipeDto)
    {
        var recipe = new Recipe
        {
            Name = createRecipeDto.Name,
            CookingTimeInMinutes = createRecipeDto.CookingTimeInMinutes,
            Servings = createRecipeDto.NumberOfServings,
            AvatarId = createRecipeDto.AvatarId,

            Calories = createRecipeDto.Nutrients.Calories,
            Proteins = createRecipeDto.Nutrients.Proteins,
            Fats = createRecipeDto.Nutrients.Fats,
            Carbohydrates = createRecipeDto.Nutrients.Carbohydrates,

            RecipeIngredients = createRecipeDto.Ingredients.Select(MapDtoToRecipeIngredient).ToList(),
            RecipeSteps = createRecipeDto.InstructionSteps.Select(MapDtoToRecipeStep).ToList(),
            CookingTools = createRecipeDto.CookingTools.Select(MapDtoToCookingTool).ToList()
        };

        var createdRecipe = await recipeRepository.CreateAsync(recipe);
        return MapRecipeToDto(createdRecipe);
    }

    private static RecipeDto MapRecipeToDto(Recipe recipe)
    {
        return new RecipeDto
        (
            recipe.Id,
            recipe.Name,
            recipe.AvatarId,
            recipe.CookingTimeInMinutes,
            recipe.Servings,
            recipe.RecipeIngredients.Select(MapRecipeIngredientToDto),
            recipe.RecipeSteps.Select(MapRecipeStepToDto),
            recipe.CookingTools.Select(MapCookingToolToDto),
            new NutrientsDto
            (
                recipe.Calories,
                recipe.Proteins,
                recipe.Fats,
                recipe.Carbohydrates
            )
        );
    }

    private static RecipeIngredientDto MapRecipeIngredientToDto(RecipeIngredient recipeIngredient)
    {
        return new RecipeIngredientDto
        (
            recipeIngredient.IngredientId,
            recipeIngredient.MeasureId,
            recipeIngredient.Amount
        );
    }

    private static RecipeIngredient MapDtoToRecipeIngredient(RecipeIngredientDto recipeIngredientDto)
    {
        return new RecipeIngredient
        {
            IngredientId = recipeIngredientDto.IngredientId,
            MeasureId = recipeIngredientDto.MeasureId,
            Amount = recipeIngredientDto.Amount
        };
    }
    
    private static RecipeStepDto MapRecipeStepToDto(RecipeStep recipeStep)
    {
        return new RecipeStepDto
        (
            recipeStep.Order,
            recipeStep.Description
        );
    }
    
    private static RecipeStep MapDtoToRecipeStep(RecipeStepDto recipeStepDto)
    {
        return new RecipeStep
        {
            Order = recipeStepDto.Order,
            Description = recipeStepDto.Description
        };
    }
    
    private static CookingToolDto MapCookingToolToDto(RecipeCookingTool recipeCookingTool)
    {
        return new CookingToolDto(recipeCookingTool.CookingToolId);
    }
    
    private static RecipeCookingTool MapDtoToCookingTool(CookingToolDto cookingToolDto)
    {
        return new RecipeCookingTool
        {
            CookingToolId = cookingToolDto.Id
        };
    }
}