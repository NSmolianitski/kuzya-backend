namespace KuzyaBackend.Web.DTOs.MealListController;

public record CreateMealListDto(
    string Name,
    List<CreateMealGroupDto> MealGroups
);