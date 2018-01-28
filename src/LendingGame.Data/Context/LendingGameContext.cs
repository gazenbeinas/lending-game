using LendingGame.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LendingGame.Data.Context
{
    public class LendingGameContext : DbContext
    {
        public LendingGameContext(DbContextOptions<LendingGameContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity(FriendMapping.Map());
            modelBuilder.Entity(GameMapping.Map());
            modelBuilder.Entity(LoanMapping.Map());

            base.OnModelCreating(modelBuilder);
        }
    }
}