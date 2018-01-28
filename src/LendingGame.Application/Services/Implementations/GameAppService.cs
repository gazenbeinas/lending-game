using System.Collections.Generic;
using AutoMapper;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Games.Services.Interfaces;

namespace LendingGame.Application.Services.Implementations
{
    public class GameAppService : IGameAppService
    {
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly IGameService _gameService;
        readonly IMapper _mapper;
        readonly IDeletableAppService<GameViewModel> _deletableAppService;
        readonly IFindableIdAppService<GameViewModel> _findableIdAppService;
        readonly ILoadAllAppService<GameViewModel> _loadAllAppService;
        readonly ICreatableAppService<GameViewModel> _createbleAppService;
        readonly IUpdatableAppService<GameViewModel> _updatableAppService;

        public GameAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IGameService gameService,
            IMapper mapper,
            IDeletableAppService<GameViewModel> deletableAppService,
            IFindableIdAppService<GameViewModel> findableIdAppService,
            ILoadAllAppService<GameViewModel> loadAllAppService,
            ICreatableAppService<GameViewModel> createbleAppService,
            IUpdatableAppService<GameViewModel> updatableAppService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _gameService = gameService;
            _mapper = mapper;
            _deletableAppService = deletableAppService;
            _findableIdAppService = findableIdAppService;
            _loadAllAppService = loadAllAppService;
            _createbleAppService = createbleAppService;
            _updatableAppService = updatableAppService;
        }

        public IEnumerable<GameViewModel> GetAllAvailableForLoan()
        {
            using (_unitOfWorkFactory.StartUnitOfWork())
                return _mapper.Map<IEnumerable<GameViewModel>>(
                    _gameService.LoadAvailableForLoan());
        }

        public void Delete(string entityId) =>
            _deletableAppService.Delete(entityId);

        public GameViewModel FindById(string id) =>
            _findableIdAppService.FindById(id);

        public IEnumerable<GameViewModel> LoadAll() =>
            _loadAllAppService.LoadAll();

        public GameViewModel Create(GameViewModel appModel) =>
            _createbleAppService.Create(appModel);

        public GameViewModel Update(GameViewModel appModel) =>
            _updatableAppService.Update(appModel);
    }
}