using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Application.Interfaces;
using MusicCatalog.Application.Services;
using MusicCatalog.Application.ViewModels.Album;
using MusicCatalog.Application.ViewModels.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application
{
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
}
