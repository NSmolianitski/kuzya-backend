namespace Kuzya_Backend.Models;

public class RecipeIngredient
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public long IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public long MeasureId { get; set; }
    public Measure Measure { get; set; }
    public double Amount { get; set; }
}