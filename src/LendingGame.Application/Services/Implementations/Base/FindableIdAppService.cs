using AutoMapper;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Application.Services.Implementations.Base
{
    public class FindableIdAppService<TAppModel, TDomainEntity> :
        SegregatedAppService<TAppModel, TDomainEntity>,
        IFindableIdAppService<TAppModel>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly IFindableIdService<TDomainEntity> _service;

        public FindableIdAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper,
            IFindableIdService<TDomainEntity> service)
            : base(unitOfWorkFactory, mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _service = service;
        }

        public TAppModel FindById(string id)
        {
            using (_unitOfWorkFactory.StartUnitOfWork())
                return ConvertToViewModel(
                    _service.FindById(id));
        }
    }
}