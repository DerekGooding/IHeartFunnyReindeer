using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TextAttempt.Services;

namespace TextAttempt;

public static class Program
{
    public static async Task Main()
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        builder.Services.AddSingleton<ThemeService>();

        await builder.Build().RunAsync();
    }
}
