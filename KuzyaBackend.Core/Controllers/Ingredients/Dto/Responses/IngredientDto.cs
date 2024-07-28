using KuzyaBackend.Controllers.Dto;

namespace KuzyaBackend.Controllers.Ingredients.Dto.Responses;

public record IngredientDto(
    long Id, 
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);