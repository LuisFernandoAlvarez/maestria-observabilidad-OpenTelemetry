using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using observabilidad_Servicio_A.Api.Models;
using observabilidad_Servicio_A.Api.Data;

namespace observabilidad_Servicio_A.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _db;

    private static readonly ActivitySource Source =
        new("service-a");

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        using var activity =
            Source.StartActivity("query-orders");

        return Ok(_db.Orders.ToList());
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        using var activity =
            Source.StartActivity("create-order");

        _db.Orders.Add(order);

        await _db.SaveChangesAsync();

        return Ok(order);
    }
}