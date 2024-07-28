namespace KuzyaBackend.Web.DTOs.RecipeController;

public record RecipeIngredientDto(
    long IngredientId,
    long MeasureId,
    double Amount
);