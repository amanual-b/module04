using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;

namespace AddisEatsRestaurants.Api.Mapper;

public static class RestaurantMapper
{
    public static RestaurantDTO ToDTO(this Restaurant restaurant)
    {
        return new RestaurantDTO(
            restaurant.Id,
            restaurant.Name,
            restaurant.Address,
            restaurant.Phone,
            restaurant.IsActive
        );
    }
}
