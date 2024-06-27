using BlazorClient;
using BlazorClient.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//adres web api
var url = "https://localhost:7036";


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(url) });


builder.Services.AddScoped<IBookingService, BookingService>();





await builder.Build().RunAsync();
