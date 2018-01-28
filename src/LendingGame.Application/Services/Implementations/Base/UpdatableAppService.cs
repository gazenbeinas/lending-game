using System;
using AutoMapper;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Application.Services.Implementations.Base
{
    public class UpdatableAppService<TAppModel, TDomainEntity> :
        SegregatedAppService<TAppModel, TDomainEntity>,
        IUpdatableAppService<TAppModel>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        readonly IUpdatableService<TDomainEntity> _service;

        public UpdatableAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper,
            IUpdatableService<TDomainEntity> service) :
            base(unitOfWorkFactory, mapper)
        {
            _service = service;
        }

        public TAppModel Update(TAppModel appModel)
        {
            TAppModel updatedAppModel = null;

            using (var unitOfWork = UnitOfWorkFactory
                .StartUnitOfWork(true))
            {

                try
                {
                    var updatedEntity = _service.Update(
                        Mapper.Map<TDomainEntity>(appModel));

                    if (updatedEntity == null)
                        unitOfWork.Rollback();
                    else
                    {
                        updatedAppModel =
                            Mapper.Map<TAppModel>(updatedEntity);

                        unitOfWork.Save();
                        unitOfWork.Commit();
                    }
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                }
            }

            return updatedAppModel;
        }
    }
}