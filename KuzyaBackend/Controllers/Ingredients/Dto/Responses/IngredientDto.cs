namespace KuzyaBackend.Controllers.Dto.Responses;

public record IngredientDto(
    long Id, 
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);