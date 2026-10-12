using Microsoft.EntityFrameworkCore;
using observabilidad_Servicio_A.Api.Models;

namespace observabilidad_Servicio_A.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
}