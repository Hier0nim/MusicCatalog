using AutoMapper;
using FluentValidation;
using MusicCatalog.Application.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Track
{
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
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        }
    }
}
