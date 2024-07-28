using KuzyaBackend.Controllers.Dto;

namespace KuzyaBackend.Controllers.Ingredients.Dto.Requests;

public record CreateIngredientDto(
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);