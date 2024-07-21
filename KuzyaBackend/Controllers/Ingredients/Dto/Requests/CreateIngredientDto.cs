using Kuzya_Backend.Controllers.Dto;

namespace Kuzya_Backend.Controllers.Ingredients.Dto.Requests;

public record CreateIngredientDto(
    string Name, 
    long AvatarId, 
    NutrientsDto Nutrients);