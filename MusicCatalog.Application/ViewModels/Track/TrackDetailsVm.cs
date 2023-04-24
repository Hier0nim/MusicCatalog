using AutoMapper;
using MusicCatalog.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Track
{
    public class TrackDetailsVm : IMapFrom<MusicCatalog.Domain.Model.Track>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Length { get; set; }
        public DateTime DateCreated { get; set; }
        public List<ArtistForListVm> Artists { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MusicCatalog.Domain.Model.Track, TrackDetailsVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
                .ForMember(d => d.Length, opt => opt.MapFrom(s => s.Length))
                .ForMember(d => d.DateCreated, opt => opt.MapFrom(s => s.DateCreated))
                .ForMember(d => d.Artists, opt => opt.Ignore());
        }
    }
}
