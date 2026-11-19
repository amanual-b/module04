using AddisEatsRestaurants.Api.Models;

namespace AddisEatsRestaurants.Api.Services.MenuItemServices;

public interface IMenuItemService
{
    List<MenuItem> GetAll(string? category);
    MenuItem? GetById(int id);
}