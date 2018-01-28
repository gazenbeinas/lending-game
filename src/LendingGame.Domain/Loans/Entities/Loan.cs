using System;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Games.Entities;

namespace LendingGame.Domain.Loans.Entities
{
    public class Loan : EntityBase
    {
        public string FriendId { get; set; }

        public string GameId { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        public virtual Game BorrowedGame { get; set; }
        public virtual Friend Friend { get; set; }

        public virtual bool IsBorrowed =>
            !ReturnDate.HasValue ||
            ReturnDate.Value > DateTime.Now;

        public override string GenerateId() =>
            Guid.NewGuid().ToString();

        public override bool IsValid() =>
            !string.IsNullOrWhiteSpace(FriendId) &&
            !string.IsNullOrWhiteSpace(GameId) &&
            BorrowedGame?.Id == GameId &&
            Friend?.Id == FriendId &&
            (!ReturnDate.HasValue ||
             ReturnDate >= LoanDate);
    }
}