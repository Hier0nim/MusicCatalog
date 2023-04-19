﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Domain.Model
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Track> Tracks{ get;}
        public ICollection<AlbumArtist> AlbumArtists { get; set; }
        public ICollection<AlbumTag> AlbumTags { get; set; }
    }
}
