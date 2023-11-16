namespace Karami.Blazor.Frameworks.Extensions;

public static class IConfigurationBuilderExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="configurationBuilder"></param>
    /// <param name="hostEnvironment"></param>
    /// <returns></returns>
    public static IConfigurationBuilder AddJsonFiles(this IConfigurationBuilder configurationBuilder,
        IHostEnvironment hostEnvironment
    )
    {
        var culture = Path.Combine(hostEnvironment.ContentRootPath, "Configs", "Culture.json");
        var service = Path.Combine(hostEnvironment.ContentRootPath, "Configs", "Service.json");

        configurationBuilder.AddJsonFile(culture, optional: true, reloadOnChange: true)
                            .AddJsonFile(service, optional: true, reloadOnChange: true);

        return configurationBuilder;
    }
}