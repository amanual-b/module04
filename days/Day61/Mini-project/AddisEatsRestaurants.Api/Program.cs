//Day 61 Mini Project
using AddisEatsRestaurants.Api.Services.MenuItemServices;
using AddisEatsRestaurants.Api.Services.RestaurantServices;
using AddisEatsRestaurants.Api.Services.OrderService;
using AddisEatsRestaurants.Api.Services.AuthServices;
using AddisEatsRestaurants.Api.Services.UserServices;
using AddisEatsRestaurants.Api.Configuration;
using AddisEatsRestaurants.Api.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy =
    System.Text.Json.JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.DefaultIgnoreCondition =
    System.Text.Json.Serialization.JsonIgnoreCondition
    .WhenWritingNull;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Addis Eats API",
        Version = "v1",
        Description = "Ordering and delivery API for restaurant"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Enter Your Jwt token only (without the 'Bearer ' profix)."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Adding Cors

builder.Services.AddCors(options =>
 options.AddPolicy("frontend", policy =>
 policy.WithOrigins("*") // Vite
 .AllowAnyHeader()
 .AllowAnyMethod()));

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<IPasswordHasher<User>,PasswordHasher<User>>();
builder.Services.AddSingleton<DemoUserService>();

var jwt = builder.Configuration
    .GetSection("Jwt")
    .Get<JwtOptions>()!;

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
).AddJwtBearer(options =>
{
    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwt.Issuer,

            ValidateAudience = true,
            ValidAudience = jwt.Audience,

            ValidateLifetime = true,

            ClockSkew = TimeSpan.FromSeconds(30),

            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.SigningKey)
            )
        };
}); 

var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("The reuest is coming in.");

    await next();

    Console.WriteLine("The reuest is going out.");
}
);

app.Use(async (context, next) =>
{
    Console.WriteLine("The reuest is still coming in.");

    await next();

    Console.WriteLine("The reuest is still going out.");
}
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("frontend");

app.UseMiddleware<CorrelationalMiddleware>();

app.UseMiddleware<RequestTimingMiddleware>();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
