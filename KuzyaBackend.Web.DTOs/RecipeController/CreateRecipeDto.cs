namespace KuzyaBackend.Web.DTOs.RecipeController;

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