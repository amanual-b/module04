using AddisEatsRestaurants.Api.Services.RestaurantServices;
using AddisEatsRestaurants.Api.Services.MenuItemServices;
using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize]
    [HttpGet("{id:int}")]
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
    public IActionResult GetAllRestaurant([FromQuery] RestaurantQuery query )
    {
        var restaurants = _restaurantService.GetAll(query);

        return Ok(restaurants);
    }

    [HttpGet("Active")]
    public IActionResult GetAllActiveRestaurant()
    {
        var restaurants = _restaurantService.GetAllActive();
        var restaurantDTOs = restaurants.Select(r => r.ToDTO()).ToList();

        return Ok(restaurantDTOs);
    }




    [HttpGet("{id:int}/menu")]
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

    [HttpGet("{id:int}/menu/{menuId}")]
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