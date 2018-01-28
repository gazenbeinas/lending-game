//using System.Collections.Generic;
//using LendingGame.Application.Services.Interfaces;
//using LendingGame.Application.ViewModels;
//using LendingGame.Domain.Core.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace LendingGame.Web.Controllers
//{
//    public class BaseController<TViewModel, TAppService> : Controller
//        where TViewModel : class, new()
//        where TAppService : IBaseAppService<TViewModel>
//    {
//        readonly TAppService _appService;

//        public BaseController(
//            TAppService appService) =>
//            _appService = appService;

//        public IActionResult Index() =>
//            View(new List<FriendViewModel>());

//        public IActionResult SaveNew(FriendViewModel viewModel) =>
//            View("Details", _friendAppService.Create(viewModel));

//        [Route("{id}")]
//        public IActionResult Edit(string id) =>
//            View(_friendAppService.FindById(id));

//        [Route("{id}")]
//        public IActionResult Delete(string id)
//        {
//            _friendAppService.DeleteFriend(id);

//            return RedirectToAction("Index");
//        }
//    }
//}