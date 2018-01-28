using System.Collections.Generic;
using AutoMapper;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Application.Services.Implementations.Base
{
    public class LoadAllAppService<TAppModel, TDomainEntity> :
        SegregatedAppService<TAppModel, TDomainEntity>,
        ILoadAllAppService<TAppModel>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly ILoadAllService<TDomainEntity> _service;

        public LoadAllAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper,
            ILoadAllService<TDomainEntity> service)
            : base(unitOfWorkFactory, mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _service = service;
        }

        public IEnumerable<TAppModel> LoadAll()
        {
            using (_unitOfWorkFactory.StartUnitOfWork())
                return Mapper.Map<
                    IEnumerable<TDomainEntity>,
                    IEnumerable<TAppModel>>(
                    _service.LoadAll());
        }
    }
}