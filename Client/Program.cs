using BlazorWASMWebApplication.Client;
using BlazorWASMWebApplication.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IContactService, ContactService>();

builder.Services.AddHttpClient<IContactService, ContactService>(c =>
{
    c.BaseAddress = new Uri("http://localhost:8888");
});

await builder.Build().RunAsync();
