using System;
using LendingGame.Domain.Friends.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LendingGame.Data.Mappings
{
    public class FriendMapping
    {
        public static Action<EntityTypeBuilder<Friend>> Map() =>
            entity =>
            {
                entity.ToTable("Friends");

                entity.HasKey(x => x.Id);
            };
    }
}