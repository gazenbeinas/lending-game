using System;
using System.Collections.Generic;
using System.Linq;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Loans.Entities;

namespace LendingGame.Domain.Friends.Entities
{
    public sealed class Friend : EntityBase
    {
        public Friend(string id, string name, string email)
            :base(id)
        {
            Name = name;
            Email = email;

            Loans = new List<Loan>();
        }

        public Friend()
        {
            Loans = new List<Loan>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Loan> Loans { get; set; }

        public bool HasPendingLoan =>
            Loans.Any(x => x.IsBorrowed);

        public override string GenerateId() =>
            Id = Guid.NewGuid().ToString();

        public override bool IsValid() =>
            !string.IsNullOrWhiteSpace(Id) &&
            !string.IsNullOrWhiteSpace(Name) &&
            !string.IsNullOrWhiteSpace(Email);
    }
}