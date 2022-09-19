global using WebAppToModifyRecordsInDB.Web.Services;
global using WebAppToModifyRecordsInDB.Contracts.Dtos;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAppToModifyRecordsInDB.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");

builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7010") });

builder.Services.AddScoped<ILocationService, LocationService>();

await builder.Build().RunAsync();
