using AutoMapper;
using MusicCatalog.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Track
{
    public class TrackForListVm : IMapFrom<MusicCatalog.Domain.Model.Track>  
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MusicCatalog.Domain.Model.Track, TrackForListVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title));
        }

    }
}
