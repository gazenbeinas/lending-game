using System.Collections.Generic;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Friends.Services.Interfaces;

namespace LendingGame.Domain.Friends.Services.Implementations
{
    public class FriendService : IFriendService
    {
        readonly IUpdatableRepository<Friend> _updatableRepository;
        readonly IDeletable<Friend> _deletable;
        readonly IFindableId<Friend> _findableId;
        readonly ILoadAll<Friend> _loadAll;
        readonly ICreatable<Friend> _creatable;

        public FriendService(
            IUpdatableRepository<Friend> updatableRepository,
            IDeletable<Friend> deletable,
            IFindableId<Friend> findableId,
            ILoadAll<Friend> loadAll,
            ICreatable<Friend> creatable)
        {
            _updatableRepository = updatableRepository;
            _deletable = deletable;
            _findableId = findableId;
            _loadAll = loadAll;
            _creatable = creatable;
        }

        public Friend Update(Friend updatingFriend)
        {
            Friend friendToUpdate = null;

            if (updatingFriend.IsValid())
            {
                friendToUpdate = FindById(updatingFriend.Id);

                friendToUpdate.Name = updatingFriend.Name;
                friendToUpdate.Email = updatingFriend.Email;

                _updatableRepository.Update(friendToUpdate);
            }

            return friendToUpdate;
        }

        public bool Delete(string entityId) =>
            _deletable.Delete(entityId);

        public Friend FindById(string entityId) =>
            _findableId.FindById(entityId);

        public IEnumerable<Friend> LoadAll() =>
            _loadAll.LoadAll();

        public Friend Create(Friend entity) =>
            _creatable.Create(entity);
    }
}