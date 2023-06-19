using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Infrastructure.Repositories;

namespace MusicCatalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ITrackRepository, TrackRepository>();
        services.AddTransient<IAlbumRepository, AlbumRepository>();
        return services;
    }
}