using System.Collections.Generic;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class FriendController : Controller
    {
        readonly IFriendAppService _friendAppService;

        public FriendController(IFriendAppService friendAppService) =>
            _friendAppService = friendAppService;

        public IActionResult Index() =>
            View(new List<FriendViewModel>());

        public IActionResult Create() =>
            View();

        public IActionResult Update(FriendViewModel viewModel)
        {
            var updatedFriend = _friendAppService
                .Update(viewModel);

            return updatedFriend != null
                ? RedirectToAction("Details", viewModel)
                : RedirectToAction("Edit", new { viewModel.Id });
        }

        public IActionResult SaveNew(FriendViewModel viewModel) =>
            View("Details", _friendAppService.Create(viewModel));

        [Route("{id}")]
        public IActionResult Details(string id) =>
            View(_friendAppService.FindById(id));

        [Route("{id}")]
        public IActionResult Edit(string id) =>
            View(_friendAppService.FindById(id));

        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _friendAppService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}