using LendingGame.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LendingGame.Web.Controllers.Api
{
    [Authorize]
    [Route("api/friend")]
    public class FriendApiController : Controller
    {
        readonly IFriendAppService _friendAppService;

        public FriendApiController(
            IFriendAppService friendAppService) =>
            _friendAppService = friendAppService;

        [HttpGet]
        public IActionResult List() =>
            Ok(_friendAppService.LoadAll());
    }
}