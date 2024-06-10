using Entities.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;

namespace Entities.Models
{
    public class Account : IModelWithId
    {
        public Guid Id { get; init; }
        public DateTime DateCreated { get; init; }
        public AccountType AccountType { get; init; }
        public Guid OwnerId { get; init; }
        public Owner? Owner { get; init; }
    }
}
