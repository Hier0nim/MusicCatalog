using AutoMapper;
using FluentValidation;
using MusicCatalog.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalog.Application.ViewModels.Album
{
    public class NewAlbumVm : IMapFrom<Domain.Model.Album>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int PublicationYear { get; set; }
        public string Version { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewAlbumVm, Domain.Model.Album>().ReverseMap();
        }

    }

    public class NewAlbumValidation : AbstractValidator<NewAlbumVm>
    {
        public NewAlbumValidation()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
            RuleFor(x => x.Artist).NotEmpty().MaximumLength(255);
            RuleFor(x => x.PublicationYear).NotEmpty().LessThan(9999);
        }
    }
}
