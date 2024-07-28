namespace KuzyaBackend.DataAccess.Models;

public class RecipeStep
{
    public long Id { get; set; }
    public long RecipeId { get; set; }
    public Recipe Recipe { get; set; }
    public long Order { get; set; }
    public string Description { get; set; }
}