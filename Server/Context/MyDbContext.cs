using Microsoft.EntityFrameworkCore;
using Restaurante.Server.Models;
namespace Restaurante.Server.Context;

public interface IMyDbContext
{
    DbSet<Cliente> Clientes { get; set; }
    DbSet<Factura> Facturas { get; set; }
    DbSet<Mesa> Mesas { get; set; }
    DbSet<MesaStatus> MesaStatuses { get; set; }
    DbSet<MetodoPago> MetodoPagos { get; set; }
    DbSet<Pedido> Pedidos { get; set; }
    DbSet<PedidoStatus> PedidoStatuses { get; set; }
    DbSet<Producto> Productos { get; set; }
    DbSet<Reservacion> Reservaciones { get; set; }
    DbSet<RolUsuario> RolUsuarios { get; set; }
    DbSet<Usuario> Usuarios { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public class MyDbContext : DbContext, IMyDbContext
{
    private readonly IConfiguration config;

    public MyDbContext(IConfiguration _config)
    {
        config = _config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config.GetConnectionString("Restaurante"));
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    #region Tablas de mi base de datos
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Factura> Facturas { get; set; } = null!;
    public DbSet<Mesa> Mesas { get; set; } = null!;
    public DbSet<MesaStatus> MesaStatuses { get; set; } = null!;
    public DbSet<MetodoPago> MetodoPagos { get; set; } = null!;
    public DbSet<Pedido> Pedidos { get; set; } = null!;
    public DbSet<PedidoStatus> PedidoStatuses { get; set; } = null!;
    public DbSet<Producto> Productos { get; set; } = null!;
    public DbSet<Reservacion> Reservaciones { get; set; } = null!;
    public DbSet<RolUsuario> RolUsuarios { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    #endregion
}