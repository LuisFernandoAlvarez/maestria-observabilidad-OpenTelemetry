using System.Diagnostics;

private static readonly ActivitySource
ActivitySource = new("orders-service");

activity?.SetTag(
    "business.company",
    empresa);


[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(
        AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{empresa}")]
    public async Task<IActionResult> Get(
        string empresa)
    {
        var data =
            await _context.Orders
                .Where(x => x.Empresa == empresa)
                .ToListAsync();

        return Ok(data);
    }
}
