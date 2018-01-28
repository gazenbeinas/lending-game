using LendingGame.Domain.Core.Repositories;

namespace LendingGame.Data.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        readonly UnitOfWork _unitOfWork;

        public UnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public IUnitOfWork StartUnitOfWork(
            bool useTransaction = false)
        {
            _unitOfWork.InitializeContext(useTransaction);

            return _unitOfWork;
        }
    }
}