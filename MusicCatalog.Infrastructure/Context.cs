using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Domain.Model;

namespace MusicCatalog.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TrackTag> TrackTag { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Album>()
                .HasMany(i => i.Tracks)
                .WithOne(i => i.Album);

            builder.Entity<TrackTag>()
                .HasKey(it => new { it.TrackId, it.TagId });

            builder.Entity<TrackTag>()
                .HasOne(it => it.Track)
                .WithMany(i => i.TrackTags)
                .HasForeignKey(it => it.TrackId);

            builder.Entity<TrackTag>()
                .HasOne(it => it.Tag)
                .WithMany(i => i.TrackTags)
                .HasForeignKey(it => it.TagId);

            builder.Entity<AlbumTag>()
               .HasKey(it => new { it.AlbumId, it.TagId });

            builder.Entity<AlbumTag>()
                .HasOne(it => it.Album)
                .WithMany(i => i.AlbumTags)
                .HasForeignKey(it => it.AlbumId);

            builder.Entity<AlbumTag>()
                .HasOne(it => it.Tag)
                .WithMany(i => i.AlbumTags)
                .HasForeignKey(it => it.TagId);

            builder.Entity<TrackArtist>()
                .HasKey(it => new { it.TrackId, it.ArtistId });

            builder.Entity<TrackArtist>()
                .HasOne(it => it.Artist)
                .WithMany(i => i.TrackArtists)
                .HasForeignKey(it => it.ArtistId);

            builder.Entity<TrackArtist>()
                .HasOne(it => it.Track)
                .WithMany(i => i.TrackArtists)
                .HasForeignKey(it => it.TrackId);

            builder.Entity<AlbumArtist>()
                .HasKey(it => new { it.AlbumId, it.ArtistId });

            builder.Entity<AlbumArtist>()
                .HasOne(it => it.Artist)
                .WithMany(i => i.AlbumArtists)
                .HasForeignKey(it => it.ArtistId);

            builder.Entity<AlbumArtist>()
                .HasOne(it => it.Album)
                .WithMany(i => i.AlbumArtists)
                .HasForeignKey(it => it.AlbumId);

        }
    }
}
