namespace LendingGame.Domain.Core.Repositories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork StartUnitOfWork(bool useTransaction = false);
    }
}