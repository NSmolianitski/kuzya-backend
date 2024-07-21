using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Controllers.Recipes.Dto.Requests;

namespace KuzyaBackend.Controllers.Recipes.Dto;

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