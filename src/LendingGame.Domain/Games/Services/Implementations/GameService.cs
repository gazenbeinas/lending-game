using System.Collections.Generic;
using LendingGame.Domain.Core.Repositories.Base;
using LendingGame.Domain.Core.Services.Segregation.Internal.Interfaces;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Games.Services.Interfaces;

namespace LendingGame.Domain.Games.Services.Implementations
{
    public class GameService : IGameService
    {
        readonly IUpdatableRepository<Game> _updatableRepository;

        readonly IDeletable<Game> _deletable;
        readonly IFindableId<Game> _findableId;
        readonly ILoadAll<Game> _loadAll;
        readonly ICreatable<Game> _creatable;
        readonly ILoadBy<Game> _loadBy;

        public GameService(
            IUpdatableRepository<Game> updatableRepository,
            IDeletable<Game> deletable,
            IFindableId<Game> findableId,
            ILoadAll<Game> loadAll,
            ICreatable<Game> creatable,
            ILoadBy<Game> loadByEntityService)
        {
            _updatableRepository = updatableRepository;
            _deletable = deletable;
            _findableId = findableId;
            _loadAll = loadAll;
            _creatable = creatable;
            _loadBy = loadByEntityService;
        }

        public IEnumerable<Game> LoadAvailableForLoan() =>
            _loadBy.LoadBy(game => !game.IsBorrowed);

        public Game Update(Game updatingGame)
        {
            if (!updatingGame.IsValid())
                return null;

            var gameToUpdate = FindById(updatingGame.Id);

            gameToUpdate.Name = updatingGame.Name;

            _updatableRepository.Update(gameToUpdate);

            return gameToUpdate;
        }

        public bool Delete(string entityId) =>
            _deletable.Delete(entityId);

        public Game FindById(string entityId) =>
            _findableId.FindById(entityId);

        public IEnumerable<Game> LoadAll() =>
            _loadAll.LoadAll();

        public Game Create(Game entity) =>
            _creatable.Create(entity);
    }
}