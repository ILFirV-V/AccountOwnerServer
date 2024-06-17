namespace Domain.Models
{
    public class Owner
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public DateTime DateOfBirth { get; init; }

        public string? Address { get; init; }

        public ICollection<Account>? Accounts { get; init; }
    }
}
