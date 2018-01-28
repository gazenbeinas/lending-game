namespace LendingGame.Application.Services.Interfaces.Base
{
    public interface IFindableIdAppService<out TAppModel>
    {
        TAppModel FindById(string id);
    }
}