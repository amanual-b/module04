using AddisEatsRestaurants.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AddisEatsRestaurants.Api.Services.UserServices;

public class DemoUserService
{
    private readonly List<User> _user = new();

    public DemoUserService(IPasswordHasher<User> haser) 
    {
        var customer = new User
        {
            Id = 1,
            FullName = "Almaz Bekele",
            Phone = "0911234567",
            Role = "Customer"
        };

        customer.PasswordHash = haser.HashPassword(customer, "Addis@123");
         
        _user.Add(customer);
    }

    public User? FindByPhone(string phone)
    {
        return _user.FirstOrDefault(u=> u.Phone == phone);
    }
}