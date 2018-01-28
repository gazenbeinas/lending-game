using System;
using AutoMapper;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Application.Services.Implementations.Base
{
    public class CreatableAppService<TAppModel, TDomainEntity>
        :SegregatedAppService<TAppModel, TDomainEntity>,
        ICreatableAppService<TAppModel>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        readonly ICreatableService<TDomainEntity> _service;

        public CreatableAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper,
            ICreatableService<TDomainEntity> service)
            : base(unitOfWorkFactory, mapper)
        {
            _service = service;
        }

        public TAppModel Create(TAppModel appModel)
        {
            TAppModel createdViewModel = null;

            using (var unitOfWork =
                UnitOfWorkFactory.StartUnitOfWork(true))
            {
                try
                {
                    var createdEntity = _service.Create(
                        Mapper.Map<TAppModel, TDomainEntity>(
                            appModel));

                    if (createdEntity == null)
                        unitOfWork.Rollback();
                    else
                    {
                        createdViewModel = ConvertToViewModel(
                            createdEntity);

                        unitOfWork.Save();
                        unitOfWork.Commit();
                    }
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    return null;
                }
            }

            return createdViewModel;
        }
    }
}