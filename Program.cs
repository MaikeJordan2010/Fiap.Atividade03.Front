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
//builder.Services.AddHttpClient();


builder.Services.AddHttpClient(
               Configuracoes.HttpClientName,
               x =>
               {
                   x.BaseAddress = new Uri(Configuracoes.UrlAPIBrasil);
                   x.BaseAddress = new Uri(Configuracoes.UrlLocal);
                   x.BaseAddress = new Uri(Configuracoes.UrlAPI);
               }
    );

//builder.Services.AddHttpClient(
//               "API",
//               x =>
//               {
//                   //x.BaseAddress = new Uri(Configuracoes.UrlAPIBrasil);
//                   x.BaseAddress = new Uri(Configuracoes.UrlLocal);
//                   x.BaseAddress = new Uri(Configuracoes.UrlAPI);
//                   x.DefaultRequestHeaders.UserAgent.ParseAdd("HttpClient/8.0");
//               }
//    );

builder.Services.AddMudServices();
await builder.Build().RunAsync();
