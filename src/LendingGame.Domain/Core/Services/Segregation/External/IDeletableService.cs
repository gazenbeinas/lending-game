namespace LendingGame.Domain.Core.Services.Segregation.External
{
    public interface IDeletableService<TEntity>
    {
        bool Delete(string id);
    }
}