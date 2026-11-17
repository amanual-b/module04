using AddisEatsRestaurants.Api.Services.RestaurantServices;
using AddisEatsRestaurants.Api.Services.MenuItemServices;
using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace AddisEatsRestaurants.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]

public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly IMenuItemService _menuItemService;

    public RestaurantController(IRestaurantService restaurantService, IMenuItemService menuItemService)
    {
        _restaurantService = restaurantService;
        _menuItemService = menuItemService;
    }

    [HttpGet("{id}")]
    public IActionResult GetRestaurant(int id)
    {
        var restaurant = _restaurantService.GetById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }

    [HttpGet()]
    public IActionResult GetAllRestaurant([FromQuery] string? address, [FromQuery] int page = 1, [FromQuery] int pagesize = 3)
    {
        var restaurants = _restaurantService.GetAll(address, page, pagesize);
        var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();

        return Ok(restaurantDTOs);
    }

    [HttpGet("{id}/menu")]
    public IActionResult GetRestaurantMenu(int id, [FromQuery] string? category)
    {
        var restaurant = _restaurantService.GetById(id);
        if (restaurant == null)
        {
            return NotFound();
        }
        var items = _menuItemService.GetAll(category);

        return Ok(new Dictionary<string, object>{ ["restaurant"] = restaurant, ["menu"] = items });
    }

    [HttpGet("{id}/menu/{menuId}")]
    public IActionResult GetRestaurantMenu(int id, int menuId)
    {
        var restaurant = _restaurantService.GetById(id);
        if (restaurant == null)
        {
            return NotFound();
        }

        var items = _menuItemService.GetById(menuId);
        if (items == null)
        {
            return Ok(new List<string> ());
        }

        return Ok(new Dictionary<string, object> { ["Restaurant"] = restaurant, ["Menu"] = items });
    }
}