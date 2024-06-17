using Domain.Enums;

namespace Domain.Models
{
    public record Account
    {
        public Guid Id { get; init; }
        public DateTime DateCreated { get; init; }
        public AccountType AccountType { get; init; }
        public Guid OwnerId { get; init; }
        public Owner? Owner { get; init; }
    }
}
