using Karami.Core.Common.ClassExtensions;

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
        
        configurationBuilder.AddCoreEnvConfig(hostEnvironment)
                            .AddJsonFile(culture, optional: true, reloadOnChange: true);

        return configurationBuilder;
    }
}