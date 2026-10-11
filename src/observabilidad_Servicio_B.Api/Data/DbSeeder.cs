using ServiceB.Api.Models;

namespace ServiceB.Api.Data;

public static class DbSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Orders.Any())
            return;

        context.Orders.AddRange(

            new Order
            {
                Empresa = "A",
                Cliente = "Juan Perez",
                Valor = 1500
            },

            new Order
            {
                Empresa = "A",
                Cliente = "Carlos Ruiz",
                Valor = 2200
            },

            new Order
            {
                Empresa = "B",
                Cliente = "Maria Garcia",
                Valor = 900
            },

            new Order
            {
                Empresa = "B",
                Cliente = "Pedro Castro",
                Valor = 1300
            }
        );

        context.SaveChanges();
    }
}