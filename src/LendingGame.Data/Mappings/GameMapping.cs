using System;
using LendingGame.Domain.Games.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LendingGame.Data.Mappings
{
    public class GameMapping
    {
        public static Action<EntityTypeBuilder<Game>> Map() =>
            entity =>
            {
                entity.ToTable("Games");

                entity.HasKey(x => x.Id);
            };
    }
}