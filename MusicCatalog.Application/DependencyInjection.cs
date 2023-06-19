using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.Services;

namespace MusicCatalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ITrackService, TrackService>();
        services.AddTransient<IAlbumService, AlbumService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}