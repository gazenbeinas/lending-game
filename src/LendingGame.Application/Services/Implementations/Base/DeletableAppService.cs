using System;
using AutoMapper;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Domain.Core.Entities;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;

namespace LendingGame.Application.Services.Implementations.Base
{
    public class DeletableAppService<TAppModel, TDomainEntity> :
        SegregatedAppService<TAppModel, TDomainEntity>,
        IDeletableAppService<TAppModel>
        where TAppModel : class, new()
        where TDomainEntity : EntityBase
    {
        readonly IDeletableService<TDomainEntity> _service;

        public DeletableAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IMapper mapper,
            IDeletableService<TDomainEntity> service)
            : base(unitOfWorkFactory, mapper)
        {
            _service = service;
        }

        public virtual void Delete(string entityId)
        {
            using (var unitOfWork = UnitOfWorkFactory.StartUnitOfWork(true))
            {
                try
                {
                    var successfullyDeleted = _service
                        .Delete(entityId);

                    if (successfullyDeleted)
                    {
                        unitOfWork.Save();
                        unitOfWork.Commit();
                    }
                    else
                        unitOfWork.Rollback();
                }
                catch (Exception ex)
                {
                    unitOfWork.Rollback();
                }
            }
        }
    }
}