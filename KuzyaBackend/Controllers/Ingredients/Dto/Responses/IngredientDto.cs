using Kuzya_Backend.Controllers.Dto;

namespace Kuzya_Backend.Controllers.Ingredients.Dto.Responses;

public record IngredientDto(
    long Id, 
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);