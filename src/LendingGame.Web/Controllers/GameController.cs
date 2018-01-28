using System.Collections.Generic;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class GameController : Controller
    {
        readonly IGameAppService _gameAppService;

        public GameController(IGameAppService gameAppService) =>
            _gameAppService = gameAppService;

        public IActionResult Index() =>
            View(new List<GameViewModel>());

        public IActionResult Create() =>
            View();

        public IActionResult SaveNew(GameViewModel viewModel)
        {
            var game = _gameAppService.Create(viewModel);

            return View("Details", game);
        }

        [Route("{id}")]
        public IActionResult Details(string id) =>
            View(_gameAppService.FindById(id));

        [Route("{id}")]
        public IActionResult Edit(string id) =>
            View(_gameAppService.FindById(id));

        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _gameAppService
                .Delete(id);

            return RedirectToAction("Index");
        }

        public IActionResult Update(GameViewModel viewModel)
        {
            var updatedFriend = _gameAppService
                .Update(viewModel);

            return updatedFriend != null
                ? RedirectToAction("Details", viewModel)
                : RedirectToAction("Edit", new { viewModel.Id });
        }
    }
}