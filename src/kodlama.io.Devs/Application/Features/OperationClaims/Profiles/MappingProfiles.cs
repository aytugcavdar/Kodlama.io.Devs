using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();




            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, UpdatedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
            CreateMap<OperationClaim, DeletedOperationClaimDto>().ReverseMap();



    


        }
    }
}
