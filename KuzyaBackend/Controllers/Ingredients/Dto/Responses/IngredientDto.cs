namespace KuzyaBackend.Controllers.Dto.Responses;

public record IngredientDto(
    long Id, 
    string Name, 
    long AvatarId, 
    double Calories,
    double Proteins,
    double Fats,
    double Carbohydrates);