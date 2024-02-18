namespace Stereograph.TechnicalTest.Api.Features;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions class
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add features services
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void AddFeatures(this IServiceCollection services)
    {
        services.AddTransient<IPersonService, PersonService>();
    }
}
