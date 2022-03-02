using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Catalog.Client;
using MudBlazor.Services;
using Syncfusion.Blazor;
using Catalog.Client.Services.Core;
using Catalog.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
    BaseAddress = new Uri("https://localhost:5001")
}) ;
builder.Services.AddMudServices();
builder.Services.AddScoped<IProductService,ProductService>();
//builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
await builder.Build().RunAsync();
