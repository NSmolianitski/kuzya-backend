namespace KuzyaBackend.Web.DTOs.RecipeController;

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