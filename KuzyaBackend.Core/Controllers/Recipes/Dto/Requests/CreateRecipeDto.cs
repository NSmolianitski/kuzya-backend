using KuzyaBackend.Controllers.Dto;

namespace KuzyaBackend.Controllers.Recipes.Dto.Requests;

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