using Kuzya_Backend.Controllers.Dto;

namespace Kuzya_Backend.Controllers.Recipes.Dto.Responses;

public record RecipeDto(
    long Id,
    string Name,
    long AvatarId,
    int CookingTimeInMinutes,
    int Servings,
    IEnumerable<RecipeIngredientDto> Ingredients,
    IEnumerable<RecipeStepDto> InstructionSteps,
    IEnumerable<CookingToolDto> CookingTools,
    NutrientsDto Nutrients
);