namespace KuzyaBackend.Web.DTOs.MealListController;

public record MealGroupDto(
    string Name,
    List<MealGroupRecipeDto> Recipes
);