using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Games.Repositories;

namespace LendingGame.Data.Repositories
{
    public class GameRepository :
        BaseRepository<Game>,
        IGameRepository
    {
        public GameRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Game FindBy(Expression<Func<Game, bool>> filter) =>
            FindBy(filter, x => x.Loans);

        public override IEnumerable<Game> LoadBy(
            Expression<Func<Game, bool>> filter) =>
            LoadBy(filter, x => x.Loans);

        public override IEnumerable<Game> LoadAll() =>
            LoadAll(x => x.Loans);

        public Game FindById(string id) =>
            FindBy(x => x.Id == id);
    }
}