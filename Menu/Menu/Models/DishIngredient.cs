namespace Menu.Models;

public class DishIngredient
{
    public long DishId { get; set; }
    public Dish Dish { get; set; }

    public long IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}
