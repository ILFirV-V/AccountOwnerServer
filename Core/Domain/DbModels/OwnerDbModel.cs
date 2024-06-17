using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Domain.DbModels
{
    [Table("owner")]
    public class OwnerDbModel : IEntity
    {
        [Column("OwnerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string? Address { get; set; }

        public IEnumerable<AccountDbModel>? Accounts { get; set; }
    }
}