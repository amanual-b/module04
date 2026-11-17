using AddisEatsRestaurants.Api.Models;

namespace AddisEatsRestaurants.Api.Services.RestaurantServices;

public interface IRestaurantService
{
    Restaurant? GetById(int id);
    List<Restaurant> GetAll(string? address, int page, int pageSize);
}