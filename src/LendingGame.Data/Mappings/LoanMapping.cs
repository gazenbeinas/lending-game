using System;
using LendingGame.Domain.Loans.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LendingGame.Data.Mappings
{
    public class LoanMapping
    {
        public static Action<EntityTypeBuilder<Loan>> Map() =>
            entity =>
            {
                entity.ToTable("Loans");

                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.BorrowedGame)
                    .WithMany(x => x.Loans)
                    .HasForeignKey(x => x.GameId)
                    .IsRequired();

                entity.HasOne(x => x.Friend)
                    .WithMany(x => x.Loans)
                    .HasForeignKey(x => x.FriendId)
                    .IsRequired();
            };
    }
}