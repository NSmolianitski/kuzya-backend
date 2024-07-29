namespace KuzyaBackend.Web.DTOs.MealListController;

public record MealListDto(
    long Id,
    string Name,
    List<MealGroupDto> MealGroups
);