using System.ComponentModel.DataAnnotations;
using AddisEatsRestaurants.Api.Validation;

namespace AddisEatsRestaurants.Api.DTOs;

public record CreateOrderDTO(
    ///<summary>
    ///The Id of the restaurant to order from.
    ///</summary>
    ///<example>14</example>
    [Range(1,int.MaxValue, ErrorMessage = "Restaurant ID must be a positive integer.")]
    int RestaurantID,
    int MenuItemId,
    [Required(ErrorMessage = "Customer name is required.")]
    string CustomerName,
    ///<summary>
    ///The delivery ae in Addis Ababa.
    /// </summary>
    /// <example>Bole</example>
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