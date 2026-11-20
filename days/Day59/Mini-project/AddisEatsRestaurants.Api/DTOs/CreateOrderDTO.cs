using System.ComponentModel.DataAnnotations;
using AddisEatsRestaurants.Api.Validation;

namespace AddisEatsRestaurants.Api.DTOs;

public record CreateOrderDTO(
    [Range(1,int.MaxValue, ErrorMessage = "Restaurant ID must be a positive integer.")]
    int RestaurantID,
    int MenuItemId,
    [Required(ErrorMessage = "Customer name is required.")]
    string CustomerName,
    [StringLength(60, MinimumLength = 1, ErrorMessage = "Deliery address is required.")]
    string DeliveryAddress,
    [Required(ErrorMessage = "Customer phone is required.")]
    [EthiopianMobile]
    string CustomerPhone,
    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 59.")]
    int Quantity,
    [Required(ErrorMessage = "quantity is reuired.")]
    [ETBAmount]
    decimal TotalAmount
);