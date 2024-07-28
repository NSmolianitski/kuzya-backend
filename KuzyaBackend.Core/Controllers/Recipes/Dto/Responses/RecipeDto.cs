using KuzyaBackend.Controllers.Dto;

namespace KuzyaBackend.Controllers.Recipes.Dto.Responses;

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