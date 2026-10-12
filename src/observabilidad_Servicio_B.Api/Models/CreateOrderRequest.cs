namespace observabilidad_Servicio_B.Api.Models;

public class CreateOrderRequest
{
    public string Product { get; set; } = string.Empty;

    public decimal Price { get; set; }
}