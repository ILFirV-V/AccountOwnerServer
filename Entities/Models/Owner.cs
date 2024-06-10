using Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Owner : IModelWithId
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string? Address { get; init; }

        public ICollection<Account>? Accounts { get; init; }
    }
}
