using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWASMWebApplication.Client;
using BlazorWASMWebApplication.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddHttpClient<ContactService>(x => x.BaseAddress = new Uri("http://localhost:8888"));
//builder.Services.AddHttpClient();
builder.Services.AddTransient<IContactService, ContactService>();
//builder.Services.AddTransient<HttpClient>();
await builder.Build().RunAsync();
