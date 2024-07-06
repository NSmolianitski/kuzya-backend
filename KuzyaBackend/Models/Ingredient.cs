namespace KuzyaBackend.Models;

public class Ingredient
{
    public long Id { get; set; }
    public string Name { get; set; }
    public long AvatarId { get; set; }

    // Nutrients
    public double Calories { get; set; }
    public double Proteins { get; set; }
    public double Fats { get; set; }
    public double Carbohydrates { get; set; }
}