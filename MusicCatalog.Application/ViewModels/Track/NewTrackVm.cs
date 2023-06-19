using AutoMapper;
using FluentValidation;
using MusicCatalog.Application.Mapping;

namespace MusicCatalog.Application.ViewModels.Track;

public class NewTrackVm : IMapFrom<Domain.Model.Track>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Length { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewTrackVm, Domain.Model.Track>().ReverseMap();
    }
}

public class NewTrackValidation : AbstractValidator<NewTrackVm>
{
    public NewTrackValidation()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Length).NotEmpty();
    }
}