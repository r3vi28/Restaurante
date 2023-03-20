using System.Collections.Immutable;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Restaurante.Client;
using Restaurante.Client.Managers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUsuarioRolManager, UsuarioRolManager>();
builder.Services.AddScoped<IClienteManager, ClienteManager>();
builder.Services.AddScoped<IFacturaManager, FacturaManager>();
builder.Services.AddScoped<IMesaManager, MesaManager>();
builder.Services.AddScoped<IMesaStatusManager, MesaStatusManager>();
builder.Services.AddScoped<IMetodoPagoManager, MetodoPagoManager>();
builder.Services.AddScoped<IPedidoManager, PedidoManager>();
builder.Services.AddScoped<IPedidoStatusManager, PedidoStatusManager>();
builder.Services.AddScoped<IProductoManager, ProductoManager>();
builder.Services.AddScoped<IReservacionManager, ReservacionManager>();
builder.Services.AddScoped<IUsuarioManager, UsuarioManager>();

await builder.Build().RunAsync();
