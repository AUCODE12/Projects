namespace Menu.Models;

public class Ingredient
{
    public long Id { get; set; }
    public string Name { get; set; }

    public List<DishIngredient>? DishIngredients { get; set; }
}
