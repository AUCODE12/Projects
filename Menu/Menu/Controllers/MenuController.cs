using Microsoft.AspNetCore.Mvc;
using Menu.Models;
using Menu.Data;
using Microsoft.EntityFrameworkCore;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;
        public MenuController(MenuContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        { 
            var dishes = from d in _context.Dishes
                       select d;
            if (!string.IsNullOrEmpty(searchString))
            {
                dishes = dishes.Where(s => s.Name.Contains(searchString));
                return View(await dishes.ToListAsync());
            }
            return View(await dishes.ToListAsync());
        }
        public async Task<IActionResult> Details(long? id)
        {
            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dish is null) return NotFound();
            return View(dish);
        }
    }
}
