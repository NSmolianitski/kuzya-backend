namespace KuzyaBackend.Controllers.Dto;

public record CreateIngredientDto(
    string Name, 
    long AvatarId, 
    double Calories,
    double Proteins,
    double Fats,
    double Carbohydrates);