using KuzyaBackend.Controllers.Dto;

namespace KuzyaBackend.Controllers.Recipes.Dto.Requests;

public record CreateRecipeDto(
    string Name,
    NutrientsDto Nutrients,
    int CookingTimeInMinutes,
    int NumberOfServings,
    long AvatarId,
    List<RecipeIngredientDto> Ingredients,
    List<RecipeToolDto> Tools);