using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;

namespace AddisEatsRestaurants.Api.Services.OrderService;

public class OrderService : IOrderService
{
    private static List<Order> _orders = new List<Order>();

    private static int _nextId = 1;

    public Order? GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id); 
    }

    public Order CreateOrder(CreateOrderDTO createDTO)
    {
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
        return o;
    }
}