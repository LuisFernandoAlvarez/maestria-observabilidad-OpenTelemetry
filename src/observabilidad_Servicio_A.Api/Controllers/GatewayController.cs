[ApiController]
[Route("api")]
public class GatewayController : ControllerBase
{
    private readonly HttpClient _http;

    public GatewayController(
         HttpClient http)
    {
         _http = http;
    }

    [HttpGet("empresa-a/pedidos")]
    public async Task<IActionResult> A()
    {
        var result =
          await _http.GetStringAsync(
             "http://service-b/orders/A");

        return Ok(result);
    }

    [HttpGet("empresa-b/pedidos")]
    public async Task<IActionResult> B()
    {
        var result =
          await _http.GetStringAsync(
             "http://service-b/orders/B");

        return Ok(result);
    }
}
