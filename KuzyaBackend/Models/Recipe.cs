namespace KuzyaBackend.Models;

public class Recipe
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AvatarId { get; set; }

    public int CookingTimeInMinutes { get; set; }
    public int Servings { get; set; }

    public List<RecipeIngredient> Ingredients { get; set; } = [];
    public List<RecipeStep> RecipeSteps { get; set; } = [];
    
    // Nutrients
    public double Calories { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }
    public double Carbohydrates { get; set; }
}