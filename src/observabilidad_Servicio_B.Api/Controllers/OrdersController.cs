using Microsoft.AspNetCore.Mvc;
using observabilidad_Servicio_B.Api.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace observabilidad_Servicio_A.Api.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly HttpClient _httpClient;

    private static readonly ActivitySource Source =
        new("service-a");

    public OrdersController(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        using var activity =
            Source.StartActivity("get-orders-from-service-b");

        var response = await _httpClient.GetAsync(
            "http://service-a:8080/api/orders");

        var content =
            await response.Content.ReadAsStringAsync();

        return Content(content, "application/json");
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder(
        [FromBody] CreateOrderRequest order)
    {
        using var activity =
            Source.StartActivity("create-order-service-b");

        var response =
            await _httpClient.PostAsJsonAsync(
                "http://service-a:8080/api/orders",
                order);

        var content =
            await response.Content.ReadAsStringAsync();

        return Content(content, "application/json");
    }
}