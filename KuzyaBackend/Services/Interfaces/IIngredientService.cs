using KuzyaBackend.Controllers.Dto;
using KuzyaBackend.Controllers.Dto.Responses;

namespace KuzyaBackend.Services.Interfaces;

public interface IIngredientService
{
    IEnumerable<IngredientDto> GetAllIngredients();
    IngredientDto CreateIngredient(CreateIngredientDto createIngredientDto);
}