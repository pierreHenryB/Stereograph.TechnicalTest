namespace Stereograph.TechnicalTest.Api.Mapping;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Extensions class
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Add mapping services
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void AddMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PersonProfile));
    }
}
