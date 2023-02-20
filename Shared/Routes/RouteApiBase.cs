
namespace Restaurante.Shared.Routes;

public class RouteApiBase
{
    public const string API = "/api";
    public int Id { get; set; }
    public const string IdParameter = "{Id:int}";
}

public class AsignacionMesaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/asignacionesmesas";
    public const string GetById = $"{BASE}/{IdParameter}"; // /api/asignacionesmesas/{Id:int}
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ClienteRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/clientes";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class FacturaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/facturas";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class MesaRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/mesas";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class MesaStatusRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/mesasstatus";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class MetodoPagoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/metodospago";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class PedidoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/pedidos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class PedidoStatusRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/pedidosstatus";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ProductoRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/productos";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ReporteRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/reportes";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class ReservacionRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/reservaciones";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class RolUsuarioRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/roles";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}

public class UsuarioRouteManager: RouteApiBase
{
    public const string BASE = $"{API}/usuarios";
    public const string GetById = $"{BASE}/{IdParameter}";
    public static string BuildRoute(int Id) => GetById.Replace(IdParameter,Id.ToString());
}