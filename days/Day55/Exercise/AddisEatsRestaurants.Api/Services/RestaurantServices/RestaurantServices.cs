using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.Data;

namespace AddisEatsRestaurants.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allRestaurants = SeedData.restaurants;

    public Restaurant? GetById(int id)
    {
        return allRestaurants.Where(a => a.Id == id).FirstOrDefault();
    }

    public List<Restaurant> GetAll(string? address, int page, int pageSize)
    {
        var restaurants = allRestaurants
            .Where(a => address == null || a.Address.Contains(address))
            .OrderBy(a => a.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        return restaurants;
    }

}