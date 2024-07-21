using Kuzya_Backend.Controllers.Dto;

namespace Kuzya_Backend.Controllers.Recipes.Dto.Requests;

public record CreateRecipeDto(
    string Name,
    NutrientsDto Nutrients,
    int CookingTimeInMinutes,
    int NumberOfServings,
    long AvatarId,
    IEnumerable<RecipeIngredientDto> Ingredients,
    IEnumerable<RecipeStepDto> InstructionSteps,
    IEnumerable<CookingToolDto> CookingTools
);