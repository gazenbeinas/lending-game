namespace LendingGame.Application.Services.Interfaces.Base
{
    public interface ICreatableAppService<TAppModel>
        where TAppModel : class
    {
        TAppModel Create(TAppModel appModel);
    }
}