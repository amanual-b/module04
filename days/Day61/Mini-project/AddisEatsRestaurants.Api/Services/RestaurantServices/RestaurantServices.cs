using AddisEatsRestaurants.Api.Models;
using AddisEatsRestaurants.Api.Data;
using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Mapper;

namespace AddisEatsRestaurants.Api.Services.RestaurantServices;

public class RestaurantService : IRestaurantService
{
    private readonly List<Restaurant> allRestaurants = SeedData.restaurants;

    public Restaurant? GetById(int id)
    {
        return allRestaurants.Where(a => a.Id == id).FirstOrDefault();
    }

    public PaginatedResultDTO<RestaurantDTO> GetAll(RestaurantQuery query)
    {
        var restaurants = allRestaurants
            .Where(a => query.Address == null || a.Address.ToLower().Contains(query.Address.ToLower()))
            .Where(a => query.Name == null || a.Name.ToLower().Contains(query.Name.ToLower()))
            .Where(a => query.IsActive == null || a.IsActive == query.IsActive)
            .OrderBy(a => a.Name)
            .ToList();

        var totalCount = restaurants.Count();

        var toReturn = restaurants
            .Skip((query.Page - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToList();

        PaginatedResultDTO<RestaurantDTO> resultDTO = new PaginatedResultDTO<RestaurantDTO>
        {
            TotalCount = totalCount,
            Page = query.Page,
            PageSize = query.PageSize,
            Data = toReturn.Select(r => r.ToDTO()).ToList()
        };

        return resultDTO;
    }

    public List<Restaurant> GetAllActive()
    {
        var restaurants = allRestaurants
            .Where(a => a.IsActive)
            .OrderBy(a => a.Name)
            .ToList();
        return restaurants;
    }
}