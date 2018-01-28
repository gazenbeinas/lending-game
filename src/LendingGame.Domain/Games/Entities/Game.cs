using System;
using System.Collections.Generic;
using System.Linq;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Loans.Entities;

namespace LendingGame.Domain.Games.Entities
{
    public sealed class Game : EntityBase
    {
        public Game(string id, string name)
            : base(id)
        {
            Name = name;

            Loans = new List<Loan>();
        }

        public Game()
        {
            Loans = new List<Loan>();
        }

        public string Name { get; set; }

        public bool IsBorrowed =>
            Loans.Any(x => x.IsBorrowed);

        public ICollection<Loan> Loans { get; set; }

        public override bool IsValid() => true;

        public override string GenerateId() =>
            Id = Guid.NewGuid().ToString();
    }
}