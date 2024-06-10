using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
using System.Security.Principal;

namespace Entities.DbModels
{
    [Table("account")]
    public class AccountDbModel : IEntity
    {
        [Column("AccountId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Account type is required")]
        public AccountType AccountType { get; set; }

        [ForeignKey(nameof(Owner))]
        [Required(ErrorMessage = "Owner Id is required")]
        public Guid OwnerId { get; set; }

        public OwnerDbModel? Owner { get; set; }
    }
}