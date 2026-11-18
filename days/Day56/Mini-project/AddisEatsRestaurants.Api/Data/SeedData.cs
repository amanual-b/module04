using AddisEatsRestaurants.Api.Models;

namespace AddisEatsRestaurants.Api.Data;

public class SeedData
{
    public static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant{Id = 1, Name = "Addis Ababa Restaurant", Address = "Bole", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 2, Name = "Blue Nile Restaurant", Address = "Ayat", Phone = "123-456-7890", IsActive = false, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 3, Name = "Lucy Restaurant", Address = "Mexico", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 4, Name = "Ethio Restaurant", Address = "Megenagna", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 5, Name = "Tena Restaurant", Address = "Bole", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 6, Name = "Katenga Restaurant", Address = "Megenagna", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 7, Name = "Sishu Restaurant", Address = "Bole", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 8, Name = "Abay Restaurant", Address = "Megenagna", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 9, Name = "Fendike Restaurant", Address = "Piassa", Phone = "123-456-7890", IsActive = false, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 10, Name = "Doro Wat Restaurant", Address = "Arat Killo", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 11, Name = "Injera Restaurant", Address = "Mexico", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
        new Restaurant{Id = 12, Name = "Buna Restaurant", Address = "Piassa", Phone = "123-456-7890", IsActive = true, OwnerAddress = "456 Owner st"},
    }; 
}