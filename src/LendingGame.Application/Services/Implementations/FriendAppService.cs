using System.Collections.Generic;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;

namespace LendingGame.Application.Services.Implementations
{
    public class FriendAppService : IFriendAppService
    {
        readonly IDeletableAppService<FriendViewModel> _deletableAppService;
        readonly IFindableIdAppService<FriendViewModel> _findableIdAppService;
        readonly ILoadAllAppService<FriendViewModel> _loadAllAppService;
        readonly ICreatableAppService<FriendViewModel> _createbleAppService;
        readonly IUpdatableAppService<FriendViewModel> _updatableAppService;

        public FriendAppService(
            IDeletableAppService<FriendViewModel> deletableAppService,
            IFindableIdAppService<FriendViewModel> findableIdAppService,
            ILoadAllAppService<FriendViewModel> loadAllAppService,
            ICreatableAppService<FriendViewModel> createbleAppService,
            IUpdatableAppService<FriendViewModel> updatableAppService)
        {
            _deletableAppService = deletableAppService;
            _findableIdAppService = findableIdAppService;
            _loadAllAppService = loadAllAppService;
            _createbleAppService = createbleAppService;
            _updatableAppService = updatableAppService;
        }

        public FriendViewModel Update(FriendViewModel viewModel) =>
            _updatableAppService.Update(viewModel);

        public void Delete(string entityId) =>
            _deletableAppService.Delete(entityId);

        public FriendViewModel FindById(string id) =>
            _findableIdAppService.FindById(id);

        public IEnumerable<FriendViewModel> LoadAll() =>
            _loadAllAppService.LoadAll();

        public FriendViewModel Create(FriendViewModel appModel) =>
            _createbleAppService.Create(appModel);
    }
}