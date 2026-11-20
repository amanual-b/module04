//Day 59 Mini Project
using AddisEatsRestaurants.Api.Services.MenuItemServices;
using AddisEatsRestaurants.Api.Services.RestaurantServices;
using AddisEatsRestaurants.Api.Services.OrderService;

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
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Adding Cors

builder.Services.AddCors(options =>
 options.AddPolicy("frontend", policy =>
 policy.WithOrigins("*") // Vite
 .AllowAnyHeader()
 .AllowAnyMethod()));


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

app.UseMiddleware<RequestTimingMiddleware>();

app.UseMiddleware<CorrelationalMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
