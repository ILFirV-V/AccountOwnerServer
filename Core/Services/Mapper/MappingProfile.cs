using AutoMapper;
using Contracts.DataTransferObjects;
using Contracts.Enums;
using Domain.DbModels;
using Domain.Enums;
using Domain.Extensions;
using Domain.Models;
using Domain.Models.Parameters.Base;

namespace Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OwnerForCreationDto, OwnerDbModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Accounts, opt => opt.Ignore());

            CreateMap<OwnerForUpdateDto, OwnerDbModel>();

            CreateMap<OwnerDbModel, OwnerForUpdateDto>();

            CreateMap<AccountDbModel, AccountDto>();
            CreateMap<AccountDto, AccountDbModel>();

            CreateMap<Account, AccountDbModel>();
            CreateMap<AccountDbModel, Account>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();

            CreateMap<AccountForCreationDto, Account>();
            CreateMap<AccountTypeDto, AccountType>().ConvertUsing((value) => value.FromSrcToDst());
            CreateMap<AccountTypeDto, AccountType>().ConvertUsing((value) => value.FromSrcToDst());
            CreateMap<OwnerDto, OwnerDbModel>();
            CreateMap<OwnerDbModel, OwnerDto>();

            CreateMap<QueryStringParametersBase, GetItemsQuery>();
        }
    }
}
