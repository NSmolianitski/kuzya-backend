using KuzyaBackend.Services.Interfaces;
using KuzyaBackend.Web.DTOs.MealListController;
using Microsoft.AspNetCore.Mvc;

namespace KuzyaBackend.Web.Controllers;

[ApiController]
[Route("api/v1/meal-lists")]
public class MealListController(IMealListService mealListService)
{
    [HttpGet]
    public async Task<IActionResult> GetAllMealLists()
    {
        var mealLists = await mealListService.GetAllMealListsAsync();
        return new JsonResult(mealLists);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetMealListById(long id)
    {
        var mealList = await mealListService.GetMealListByIdAsync(id);
        return new JsonResult(mealList);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateMealList([FromBody] CreateMealListDto createMealListDto)
    {
        var mealListDto = await mealListService.CreateMealListAsync(createMealListDto);
        return new CreatedResult(nameof(CreateMealList), mealListDto);
    }
}