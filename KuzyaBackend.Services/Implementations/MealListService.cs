using KuzyaBackend.DataAccess.Interfaces;
using KuzyaBackend.DataAccess.Models;
using KuzyaBackend.Services.Exceptions;
using KuzyaBackend.Services.Interfaces;
using KuzyaBackend.Web.DTOs.MealListController;

namespace KuzyaBackend.Services.Implementations;

public class MealListService(IMealListRepository mealListRepository) : IMealListService
{
    public async Task<IEnumerable<MealListDto>> GetAllMealListsAsync()
    {
        var mealLists = await mealListRepository.GetAllAsync();
        return mealLists.Select(MapMealListToDto);
    }

    public async Task<MealListDto> GetMealListByIdAsync(long id)
    {
        var mealList = await mealListRepository.TryGetByIdAsync(id);
        if (mealList is null)
            throw new NoSuchEntityInDatabaseException($"Meal List with id {id} doesn't exist");
        
        return MapMealListToDto(mealList);
    }

    public async Task<MealListDto> CreateMealListAsync(CreateMealListDto createMealListDto)
    {
        var mealList = new MealList
        {
            Name = createMealListDto.Name,
            MealGroups = createMealListDto.MealGroups.Select(MapDtoToMealGroup).ToList()
        };
        
        var createdMealList = await mealListRepository.CreateAsync(mealList);
        return MapMealListToDto(createdMealList);
    }
    
    private static MealGroup MapDtoToMealGroup(CreateMealGroupDto createMealGroupDto)
    {
        return new MealGroup
        {
            Name = createMealGroupDto.Name,
            Recipes = createMealGroupDto.Recipes.Select(MapDtoToMealGroupRecipe).ToList()
        };
    }
    
    private static MealGroupRecipe MapDtoToMealGroupRecipe(MealGroupRecipeDto mealGroupRecipeDto)
    {
        return new MealGroupRecipe
        {
            RecipeId = mealGroupRecipeDto.RecipeId,
            Order = mealGroupRecipeDto.Order
        };
    }
    
    private static MealListDto MapMealListToDto(MealList mealList)
    {
        return new MealListDto
        (
            mealList.Id,
            mealList.Name,
            mealList.MealGroups.Select(MapMealGroupToDto).ToList()
        );
    }
    
    private static MealGroupDto MapMealGroupToDto(MealGroup mealGroup)
    {
        return new MealGroupDto
        (
            mealGroup.Name,
            mealGroup.Recipes.Select(MapMealGroupRecipeToDto).ToList()
        );
    }
    
    private static MealGroupRecipeDto MapMealGroupRecipeToDto(MealGroupRecipe mealGroupRecipe)
    {
        return new MealGroupRecipeDto
        (
            mealGroupRecipe.RecipeId,
            mealGroupRecipe.Order
        );
    }
}