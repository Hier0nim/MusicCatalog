using AutoMapper;
using MusicCatalog.Application.Mapping;
using MusicCatalog.Application.ViewModels.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Album
{
    public class AlbumForListVm : IMapFrom<MusicCatalog.Domain.Model.Album>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int PublicationYear { get; set; }
        public string Version { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MusicCatalog.Domain.Model.Album, AlbumForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Artist, opt => opt.MapFrom(s => s.Artist))
                .ForMember(d => d.PublicationYear, opt => opt.MapFrom(s => s.PublicationYear))
                .ForMember(d => d.Version, opt => opt.MapFrom(s => s.Version));
        }
    }
}
