namespace KuzyaBackend.DataAccess.Models;

public class MealList
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<MealGroup> MealGroups { get; set; } = [];
}