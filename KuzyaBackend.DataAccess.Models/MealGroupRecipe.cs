namespace KuzyaBackend.DataAccess.Models;

public class MealGroupRecipe
{
    public long Id { get; set; }
    
    public long MealGroupId { get; set; }
    public MealGroup? MealGroup { get; set; }
    
    public long RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    
    public int Order { get; set; }
}