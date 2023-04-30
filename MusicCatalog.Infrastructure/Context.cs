using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Model;

namespace MusicCatalog.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Track>()
                .HasOne(i => i.Album)
                .WithMany(i => i.Tracks)
                .HasForeignKey( i => i.AlbumId);
        }
    }
}
