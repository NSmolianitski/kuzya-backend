namespace KuzyaBackend.Controllers.Dto;

public record CreateIngredientDto(
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);