using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;

namespace AddisEatsRestaurants.Api.Services.OrderService;

public interface IOrderService
{
    Order? GetById(int id);
    Order CreateOrder(CreateOrderDTO createDTO);
}