using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.DTOs;

namespace AddisEatsRestaurants.Api.Services.RestaurantServices;

public interface IRestaurantService
{
    Restaurant? GetById(int id);
    PaginatedResultDTO<RestaurantDTO> GetAll(RestaurantQuery query);
    List<Restaurant> GetAllActive();
}