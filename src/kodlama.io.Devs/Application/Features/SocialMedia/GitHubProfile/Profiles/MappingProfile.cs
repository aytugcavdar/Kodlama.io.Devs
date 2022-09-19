using Application.Features.SocialMedia.GitHubProfile.commands.CreateGitHub;
using Application.Features.SocialMedia.GitHubProfile.Commands.DeleteGitHub;
using Application.Features.SocialMedia.GitHubProfile.Commands.UpdateGitHub;
using Application.Features.SocialMedia.GitHubProfile.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.GitHubProfile.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //ADD
            CreateMap<GitHub, CreatedGitHubDto>().ReverseMap();
            CreateMap<GitHub, CreateGitHubCommand>().ReverseMap();

            //DELETE
            CreateMap<GitHub, DeletedGitHubDto>().ReverseMap();
            CreateMap<GitHub, DeleteGitHubCommand>().ReverseMap();

            //update
            CreateMap<GitHub, UpdatedGitHubDto>().ReverseMap();
            CreateMap<GitHub, UpdateGitHubCommand>().ReverseMap();

        }
    }
}
