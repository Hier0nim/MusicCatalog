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

        }
    }
}
