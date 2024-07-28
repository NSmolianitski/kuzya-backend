using KuzyaBackend.Services.Interfaces;
using KuzyaBackend.Web.Controllers;
using KuzyaBackend.Web.DTOs;
using KuzyaBackend.Web.DTOs.IngredientController;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KuzyaBackend.Web.Tests.Controllers;

public class IngredientControllerTests
{
    private readonly Mock<IIngredientService> _mockIngredientService;
    private readonly IngredientController _controller;

    private readonly List<IngredientDto> _ingredients =
    [
        new IngredientDto(1, "Apple", 1, new NutrientsDto(10, 10, 10, 100)),
        new IngredientDto(2, "Banana", 2, new NutrientsDto(5, 1, 20, 200)),
    ];

    public IngredientControllerTests()
    {
        _mockIngredientService = new Mock<IIngredientService>();
        _controller = new IngredientController(_mockIngredientService.Object);
    }

    [Fact]
    public void GetAllIngredients_ReturnsJsonResult_WithListOfIngredients()
    {
        // Arrange
        _mockIngredientService
            .Setup(s => s.GetAllIngredientsAsync())
            .ReturnsAsync(_ingredients);

        // Act
        var result = _controller.GetAllIngredients();

        // Assert
        var jsonResult = Assert.IsType<JsonResult>(result);
        var resultValue = Assert.IsType<List<IngredientDto>>(jsonResult.Value);
        Assert.Equal(2, resultValue.Count);
    }

    [Fact]
    public void CreateIngredient_ReturnsCreatedResult_WithIngredientDto()
    {
        // Arrange
        var createIngredientDto = new CreateIngredientDto
        (
            "Pepper",
            3,
            new NutrientsDto(10, 10, 10, 100)
        );
        var responseIngredientDto = new IngredientDto
        (
            3,
            createIngredientDto.Name,
            createIngredientDto.AvatarId,
            createIngredientDto.Nutrients
        );

        _mockIngredientService
            .Setup(s => s.CreateIngredientAsync(createIngredientDto))
            .ReturnsAsync(responseIngredientDto);

        // Act
        var result = _controller.CreateIngredient(createIngredientDto);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        var resultValue = Assert.IsType<IngredientDto>(createdResult.Value);
        Assert.Equal(responseIngredientDto, resultValue);
    }
}