using AddisEatsRestaurants.Api.DTOs;
using AddisEatsRestaurants.Api.Services.UserServices;
using AddisEatsRestaurants.Api.Services.AuthServices;
using AddisEatsRestaurants.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AddisEats.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    private readonly DemoUserService _demoUserService;
    private readonly IPasswordHasher<User> _hasher;
    private readonly AuthService _authService;

    public AuthController(
        DemoUserService demoUserService,
        IPasswordHasher<User> hasher,
        AuthService authService
    )
    {
        _demoUserService = demoUserService;
        _hasher = hasher;
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponseDTO> Login(LoginDTO request)
    {
        var user = _demoUserService.FindByPhone(request.Phone);

        if (user == null)
        {
            return Unauthorized(new
            {
                message = "Invalid Phone nnumber."
            });
        }

        var result = _hasher.VerifyHashedPassword(
            user, user.PasswordHash, request.Password
        );

        if(result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new
            {
                message = "Invalid password."
            });
        }

        var accessToken = _authService.CreateAccessToken(user);

        var response = new LoginResponseDTO
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            ExpiresAtUtc = DateTime.UtcNow.AddMinutes(15)
        };

        return Ok(response);
    }
}