using Kuzya_Backend.Controllers.Dto;
using Kuzya_Backend.Controllers.Ingredients.Dto.Requests;
using Kuzya_Backend.Models;
using Kuzya_Backend.Repositories.Interfaces;
using Kuzya_Backend.Services.Implementations;
using Moq;

namespace KuzyaBackend.Tests.Services.Implementations;

public class IngredientServiceTests
{
    private readonly Mock<IIngredientRepository> _mockIngredientRepository;
    private readonly IngredientService _ingredientService;

    public IngredientServiceTests()
    {
        _mockIngredientRepository = new Mock<IIngredientRepository>();
        _ingredientService = new IngredientService(_mockIngredientRepository.Object);
    }

    [Fact]
    public async Task GetAllIngredients_ReturnsListOfIngredientDto()
    {
        // Arrange
        var ingredients = new List<Ingredient>
        {
            new Ingredient
            {
                Id = 99, Name = "Apple", AvatarId = 123, Calories = 100, Proteins = 10, Fats = 11, Carbohydrates = 12
            },
            new Ingredient
            {
                Id = 100, Name = "Banana", AvatarId = 124, Calories = 200, Proteins = 5, Fats = 1, Carbohydrates = 20
            }
        };
        _mockIngredientRepository.Setup(r => r.GetAllAsync())
            .ReturnsAsync(ingredients);

        // Act
        var result = await _ingredientService.GetAllIngredientsAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result,
            item =>
            {
                Assert.Equal(99, item.Id);
                Assert.Equal("Apple", item.Name);
                Assert.Equal(123, item.AvatarId);
                Assert.Equal(100, item.Nutrients.Calories);
                Assert.Equal(10, item.Nutrients.Proteins);
                Assert.Equal(11, item.Nutrients.Fats);
                Assert.Equal(12, item.Nutrients.Carbohydrates);
            },
            item =>
            {
                Assert.Equal(100, item.Id);
                Assert.Equal("Banana", item.Name);
                Assert.Equal(124, item.AvatarId);
                Assert.Equal(200, item.Nutrients.Calories);
                Assert.Equal(5, item.Nutrients.Proteins);
                Assert.Equal(1, item.Nutrients.Fats);
                Assert.Equal(20, item.Nutrients.Carbohydrates);
            }
        );
    }

    [Fact]
    public async Task CreateIngredient_ReturnsIngredientDto()
    {
        // Arrange
        var nutrients = new NutrientsDto(100, 10, 10, 10);
        var createIngredientDto = new CreateIngredientDto("Apple", 1, nutrients);
        var ingredientFromRepo = new Ingredient
        {
            Id = 54, Name = "Apple", AvatarId = 98, Calories = 100, Proteins = 10, Fats = 11, Carbohydrates = 12
        };
        _mockIngredientRepository.Setup(r => r.CreateAsync(It.IsAny<Ingredient>()))
            .ReturnsAsync(ingredientFromRepo);

        // Act
        var result = await _ingredientService.CreateIngredientAsync(createIngredientDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(54, result.Id);
        Assert.Equal("Apple", result.Name);
        Assert.Equal(98, result.AvatarId);
        Assert.Equal(100, result.Nutrients.Calories);
        Assert.Equal(10, result.Nutrients.Proteins);
        Assert.Equal(11, result.Nutrients.Fats);
        Assert.Equal(12, result.Nutrients.Carbohydrates);
    }
}