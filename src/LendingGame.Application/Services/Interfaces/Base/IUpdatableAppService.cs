namespace LendingGame.Application.Services.Interfaces.Base
{
    public interface IUpdatableAppService<TAppModel>
        where TAppModel : class, new()
    {
        TAppModel Update(TAppModel appModel);
    }
}