using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Friends.Repositories;

namespace LendingGame.Data.Repositories
{
    public class FriendRepository :
        BaseRepository<Friend>,
        IFriendRepository
    {
        public FriendRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public override Friend FindBy(
            Expression<Func<Friend, bool>> filter) =>
            FindBy(filter, x => x.Loans);

        public override IEnumerable<Friend> LoadAll() =>
            LoadAll(x => x.Loans);

        public Friend FindById(string id) =>
            FindBy(x => x.Id == id);
    }
}