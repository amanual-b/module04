using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Common;
using AddisEatsRestaurants.Api.Services.RestaurantServices;

namespace AddisEatsRestaurants.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static List<Order> _orders = new List<Order>();

    private static int _nextId = 1;

    private readonly IRestaurantService _restaurantService;

    public OrderService(IRestaurantService restaurantService)
    {
        _restaurantService = restaurantService;
    }

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id); 
    }

    public Result<Order> CreateOrder(CreateOrderDTO createDTO)
    {
        var restaurant = _restaurantService.GetById(createDTO.RestaurantID);

        if (restaurant == null)
        {
            return Result<Order>.Fail("RESTAURANT_NOT_FOUND", "The selected restaurant not found", 404);
        }

        if(!restaurant.IsActive)
        {
            return Result<Order>.Fail("RESTAURANT_NOT_ACTIVE", "The selected restaurant is not active", 409);
        }

        Order o = new Order
        {
            Id = _nextId++,
            RestaurantId = createDTO.RestaurantID,
            MenuItemId = createDTO.MenuItemId,
            CustomerName = createDTO.CustomerName,
            CustomerPhone = createDTO.CustomerPhone,
            Quantity = createDTO.Quantity,
            TotalAmount = createDTO.TotalAmount
        };

        _orders.Add(o);
        return Result<Order>.Ok(o);
    }
}