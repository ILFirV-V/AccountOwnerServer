using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DbModels;
using Entities.Models;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OwnerForCreationDto, OwnerDbModel>();
            CreateMap<OwnerForUpdateDto, OwnerDbModel>();
            CreateMap<OwnerDbModel, OwnerDto>();
            CreateMap<AccountDbModel, AccountDto>();
        }
    }
}
