using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguages;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Domain.Entities;
using Kodlama.io.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //LİST,GETBYID
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListByIdDto>().ReverseMap();


            //ADD
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            //DELETE
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();

            //UPDATE
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();
        }
    }
}
