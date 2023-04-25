using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddTransient<ITrackRepository, TrackRepository>();
            return services;
        }
    }
}
