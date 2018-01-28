using LendingGame.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers.Api
{
    [Authorize]
    [Route("api/game")]
    public class GameApiController : Controller
    {
        readonly IGameAppService _gameAppService;

        public GameApiController(
            IGameAppService gameAppService) =>
            _gameAppService = gameAppService;

        [HttpGet]
        public IActionResult List() =>
            Ok(_gameAppService.LoadAll());
    }
}