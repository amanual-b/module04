namespace AddisEatsRestaurants.Api.DTOs;

public record CreateOrderDTO(
    int RestaurantID,
    int MenuItemId,
    string CustomerName,
    string DeliveryAddress,
    string CustomerPhone,
    int Quantity,
    decimal TotalAmount
);