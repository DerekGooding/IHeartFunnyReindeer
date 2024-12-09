using IHeartFunnyReindeer.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace IHeartFunnyReindeer;

public static class Program
{
    public static async Task Main()
    {
        WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault();
        builder.RootComponents.Add<Console>("#app");
        builder.Services.AddSingleton<ConsoleService>();
        builder.Services.AddSingleton<ColorService>();

        builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }
}
