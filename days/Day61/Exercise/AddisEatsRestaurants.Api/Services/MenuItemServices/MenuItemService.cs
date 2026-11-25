using AddisEatsRestaurants.Api.Models;

namespace AddisEatsRestaurants.Api.Services.MenuItemServices;

public class MenuItemService : IMenuItemService
{
    private readonly List<MenuItem> _menuItems = new()
    {
        new MenuItem { Id =  1, Name = "Doro Wote", Category = "Main Dish", Price = 500m},
        new MenuItem { Id =  2, Name = "Dulet", Category = "Main Dish", Price = 400m},
        new MenuItem { Id =  3, Name = "Tibs", Category = "Main Dish", Price = 400m},
        new MenuItem { Id =  4, Name = "Kikle", Category = "Main Dish", Price = 300m},
        new MenuItem { Id =  5, Name = "Injera", Category = "Extra", Price = 30m},
        new MenuItem { Id =  6, Name = "Sufe", Category = "Side Dish", Price = 150m}
    };

    public List<MenuItem> GetAll(string? category)
    {
        var items = _menuItems
            .Where(x => category == null || x.Category.ToLower().Contains(category.ToLower()))
            .ToList();
        return items;
    }

    public MenuItem? GetById(int id)
    {
        return _menuItems.Where(o => o.Id == id).FirstOrDefault();
    }
}