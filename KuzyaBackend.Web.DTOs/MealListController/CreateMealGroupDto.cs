namespace KuzyaBackend.Web.DTOs.MealListController;

public record CreateMealGroupDto(
    string Name,
    List<MealGroupRecipeDto> Recipes
);