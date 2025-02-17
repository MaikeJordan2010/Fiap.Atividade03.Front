using Atividade03.Front;
using Atividade03.Front.Aplicacao._Contato.Comandos;
using Atividade03.Front.Aplicacao._Contato.Consultas;
using Atividade03.Front.Dominio.Sistemicas;
using Atividade03.Front.Services._Contatos;
using Atividade03.Front.Services._Municipios;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IContatoComandos, ContatoComandos>();
builder.Services.AddScoped<IContatoConsultas, ContatoConsultas>();
builder.Services.AddScoped<IContatoServices, ContatoServices>();
builder.Services.AddScoped<IObterMunicipios, ObterMunicipios>();
builder.Services.AddMudServices();
//builder.Services.AddHttpClient();

var config = builder.Configuration;
string urlApi = config.GetValue<string>("URLAPI");
string urlBrasilApi = config.GetValue<string>("URLBRASILAPI");
string urlLocal = config.GetValue<string>("URLLOCAL");

builder.Services.AddHttpClient(
               "URLS_LIBERADAS",
               x =>
               {
                   x.BaseAddress = new Uri(urlApi);
                   x.BaseAddress = new Uri(urlBrasilApi);
                   x.BaseAddress = new Uri(urlLocal);
               }
    );

builder.Services.AddMudServices();
await builder.Build().RunAsync();
