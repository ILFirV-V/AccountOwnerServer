using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DbModels;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OwnerDbModel, OwnerDto>();
            CreateMap<AccountDbModel, AccountDto>();
            CreateMap<OwnerForCreationDto, OwnerDbModel>();
            CreateMap<OwnerForUpdateDto, OwnerDbModel>();
        }
    }
}
