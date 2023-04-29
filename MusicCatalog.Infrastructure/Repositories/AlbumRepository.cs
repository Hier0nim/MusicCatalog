using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Infrastructure.Repositories
{
    internal class AlbumRepository : IAlbumRepository
    {
        private readonly Context _context;

        public AlbumRepository(Context context)
        {
            _context = context;
        }

        public int AddAlbum(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
            return album.Id;
        }

        public void DeleteAlbum(int albumId)
        {
            var album = _context.Albums.Find(albumId);
            if (album != null)
            {
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
        }

        public Album GetAlbumById(int albumId)
        {
            var album = _context.Albums.FirstOrDefault(i => i.Id == albumId);
            return album;
        }

        public IQueryable<Album> GetAlbumByProviderId(int providerId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> GetAllAlbums()
        {
            var albums = _context.Albums;
            return albums;
        }

        public void UpdateAlbum(Album album)
        {
            _context.Attach(album);
            _context.Entry(album).Property("Title").IsModified = true;
            _context.Entry(album).Property("Artist").IsModified = true;
            _context.Entry(album).Property("PublicationYear").IsModified = true;
            _context.Entry(album).Property("Version").IsModified = true;
            _context.SaveChanges();
        }
    }
}
