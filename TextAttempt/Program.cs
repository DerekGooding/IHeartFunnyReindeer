using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace TextAttempt;

public static class Program
{
    public static async Task Main()
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<Layout.Console>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}
