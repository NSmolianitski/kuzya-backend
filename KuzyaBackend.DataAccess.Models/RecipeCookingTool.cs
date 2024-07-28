namespace KuzyaBackend.DataAccess.Models;

public class RecipeCookingTool
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public long CookingToolId { get; set; }
    public CookingTool CookingTool { get; set; }
}