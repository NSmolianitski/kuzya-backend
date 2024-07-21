namespace Kuzya_Backend.Controllers.Recipes.Dto;

public record RecipeIngredientDto(
    long IngredientId,
    long MeasureId,
    double Amount
);