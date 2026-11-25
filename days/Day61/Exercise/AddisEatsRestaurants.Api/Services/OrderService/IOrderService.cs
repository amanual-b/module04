using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Common;

namespace AddisEatsRestaurants.Api.Services.OrderService;

public interface IOrderService
{
    Order? GetById(int id);
    Result<Order> CreateOrder(CreateOrderDTO createDTO);

}