namespace KuzyaBackend.Web.DTOs.IngredientController;

public record IngredientDto(
    long Id, 
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);