using System.Collections.Generic;

namespace LendingGame.Application.Services.Interfaces.Base
{
    public interface ILoadAllAppService<out TAppModel>
        where TAppModel : class
    {
        IEnumerable<TAppModel> LoadAll();
    }
}