using System;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class LoanController : Controller
    {
        readonly ILoanAppService _loanAppService;
        readonly IGameAppService _gameAppService;
        readonly IFriendAppService _friendAppService;

        public LoanController(
            ILoanAppService loanAppService,
            IGameAppService gameAppService,
            IFriendAppService friendAppService)
        {
            _loanAppService = loanAppService;
            _gameAppService = gameAppService;
            _friendAppService = friendAppService;
        }

        public IActionResult Index() =>
            View(_loanAppService.LoadAll());

        public IActionResult Create() =>
            View(new LoanViewModel
            {
                Friends = _friendAppService.LoadAll(),
                Games = _gameAppService.GetAllAvailableForLoan(),
                LoanDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(1)
            });

        public IActionResult SaveNew(LoanViewModel viewModel) =>
            View("Details", _loanAppService.Create(viewModel));

        [Route("{id}")]
        public IActionResult Details(string id) =>
            View(_loanAppService.FindById(id));

        [HttpGet]
        [Route("{id}")]
        public IActionResult Edit(string id) =>
            View(_loanAppService.FindById(id));

        [HttpPost]
        public IActionResult SaveChanges(LoanViewModel viewModel)
        {
            var updatedLoan = _loanAppService
                .UpdateReturnDate(viewModel);

            return updatedLoan != null
                ? RedirectToAction("Details", viewModel)
                : RedirectToAction("Edit", new {viewModel.Id});
        }

        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            _loanAppService
                .Delete(id);

            return RedirectToAction("Index");
        }
    }
}