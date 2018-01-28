using AutoMapper;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;

namespace LendingGame.Application.Services.Implementations.Base
{
    public abstract class SegregatedAppService<TAppModel, TDomainEntity>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        protected readonly IUnitOfWorkFactory UnitOfWorkFactory;
        protected readonly IMapper Mapper;

        protected SegregatedAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            Mapper = mapper;
        }

        protected TAppModel ConvertToViewModel(TDomainEntity entity) =>
            entity != null
                ? Mapper.Map<TDomainEntity, TAppModel>(entity)
                : null;
    }
}