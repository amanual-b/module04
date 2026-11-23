using AddisEatsRestaurants.Api.Services.OrderService;
using AddisEatsRestaurants.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using AddisEatsRestaurants.Api.Models;

namespace AddisEatsRestaurants.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {  _orderService = orderService; }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var order = _orderService.GetById(id);
        if(order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    /// <summary>
    /// Places a new order for delivey
    /// </summary
    ///
    /// <param name="request"
    /// Contains the restaurant, delivery area and order items
    /// </param>
    ///
    /// <response code==="201"
    /// The order was successfully placed.
    /// </response>
    ///
    /// <response code==="400"
    /// The submitted request contains invalid data.
    /// </response>
    ///
    /// <response code==="404"
    /// The requested restaurant was not found.
    /// </response>
    ///
    /// <response code==="409"
    /// The order conflict with the current restaurant.
    /// </response>

    [HttpPost()]
    [ProducesResponseType(
        typeof(Order),
        StatusCodes.Status201Created
    )]
    [ProducesResponseType(
        typeof(ValidationProblemDetails),
        StatusCodes.Status400BadRequest
    )]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status404NotFound
    )]
    [ProducesResponseType(
        typeof(ProblemDetails),
        StatusCodes.Status409Conflict
    )]
    public IActionResult CreateOrder([FromBody] CreateOrderDTO createDTO)
    {
        var result = _orderService.CreateOrder(createDTO);

        if(!result.IsSuccess)
        {
            return Problem(
                title: result.Error?.Message,
                statusCode: result.Error?.Status,
                detail: result.Error?.Code
            );
        }

        var order = result.Value;
        
        return CreatedAtAction(nameof(GetById), new {id= order.Id}, order);
    }
}