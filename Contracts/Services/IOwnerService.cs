using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DbModels;
using Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Services
{
    public interface IOwnerService
    {
        public Task<IEnumerable<OwnerDto>> GetAllOwners();

        public Task<OwnerDto?> GetOwnerById(Guid id);

        public Task<OwnerDto?> GetOwnerWithDetails(Guid id);

        public Task<OwnerDto?> CreateOwner(OwnerForCreationDto owner);

        public Task UpdateOwner(Guid id, OwnerForUpdateDto owner);

        public Task DeleteOwner(Guid id);
    }
}
