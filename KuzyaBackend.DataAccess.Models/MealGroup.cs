namespace KuzyaBackend.DataAccess.Models;

public class MealGroup
{
    public long Id { get; set; }
    
    public long MealListId { get; set; }
    public MealList? MealList { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public ICollection<MealGroupRecipe> Recipes { get; set; } = [];
}