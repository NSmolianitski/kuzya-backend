namespace Kuzya_Backend.Models;

public class Recipe
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AvatarId { get; set; }

    public int CookingTimeInMinutes { get; set; }
    public int Servings { get; set; }

    public ICollection<RecipeIngredient> RecipeIngredients { get; set; } = [];
    public ICollection<RecipeStep> RecipeSteps { get; set; } = [];
    public ICollection<RecipeCookingTool> CookingTools { get; set; } = [];
    
    // Nutrients
    public double Calories { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }
    public double Carbohydrates { get; set; }
}