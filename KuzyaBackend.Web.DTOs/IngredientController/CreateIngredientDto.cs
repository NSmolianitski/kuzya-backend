namespace KuzyaBackend.Web.DTOs.IngredientController;

public record CreateIngredientDto(
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);