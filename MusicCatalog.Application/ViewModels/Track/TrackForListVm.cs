using AutoMapper;
using MusicCatalog.Application.Mapping;

namespace MusicCatalog.Application.ViewModels.Track;

public class TrackForListVm : IMapFrom<Domain.Model.Track>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Length { get; set; }
    public Domain.Model.Album Album { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.Model.Track, TrackForListVm>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title))
            .ForMember(d => d.Length, opt => opt.MapFrom(s => s.Length))
            .ForMember(d => d.Album, opt => opt.MapFrom(s => s.Album));
    }
}