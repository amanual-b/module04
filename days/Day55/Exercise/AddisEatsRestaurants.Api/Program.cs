//Day 545 Exercise
using AddisEatsRestaurants.Api.Services.MenuItemServices;
using AddisEatsRestaurants.Api.Services.RestaurantServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

// Adding Cors

builder.Services.AddCors(options =>
 options.AddPolicy("frontend", policy =>
 policy.WithOrigins("*") // Vite
 .AllowAnyHeader()
 .AllowAnyMethod()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("frontend");

app.MapControllers();

app.Run();
