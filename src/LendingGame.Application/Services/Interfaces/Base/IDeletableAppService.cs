namespace LendingGame.Application.Services.Interfaces.Base
{
    public interface IDeletableAppService<TAppModel>
    {
        void Delete(string entityId);
    }
}