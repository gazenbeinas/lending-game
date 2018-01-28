using System;
using System.Collections.Generic;
using AutoMapper;
using LendingGame.Application.Services.Interfaces;
using LendingGame.Application.Services.Interfaces.Base;
using LendingGame.Application.ViewModels;
using LendingGame.Domain.Core.Repositories;
using LendingGame.Domain.Core.Services.Segregation.External;
using LendingGame.Domain.Friends.Entities;
using LendingGame.Domain.Games.Entities;
using LendingGame.Domain.Loans.Entities;
using LendingGame.Domain.Loans.Services.Interfaces;

namespace LendingGame.Application.Services.Implementations
{
    public class LoanAppService : ILoanAppService
    {
        readonly IUnitOfWorkFactory _unitOfWorkFactory;
        readonly IFindableIdService<Friend> _findableFriend;
        readonly IFindableIdService<Game> _gameService;
        readonly ILoanService _loanService;
        readonly IMapper _mapper;
        readonly IDeletableAppService<LoanViewModel> _deletableAppService;
        readonly IFindableIdAppService<LoanViewModel> _findableIdAppService;
        readonly ILoadAllAppService<LoanViewModel> _loadAllAppService;

        public LoanAppService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IFindableIdService<Friend> friendAppService,
            IFindableIdService<Game> gameAppService,
            ILoanService loanService,
            IMapper mapper,
            IDeletableAppService<LoanViewModel> deletableAppService,
            IFindableIdAppService<LoanViewModel> findableIdAppService,
            ILoadAllAppService<LoanViewModel> loadAllAppService)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _findableFriend = friendAppService;
            _gameService = gameAppService;
            _loanService = loanService;
            _mapper = mapper;
            _deletableAppService = deletableAppService;
            _findableIdAppService = findableIdAppService;
            _loadAllAppService = loadAllAppService;
        }

        public LoanViewModel Create(LoanViewModel viewModel)
        {
            Loan createdLoan;

            using (var unitOfWork = _unitOfWorkFactory
                .StartUnitOfWork(true))
            {
                try
                {
                    createdLoan = _mapper.Map<Loan>(viewModel);

                    createdLoan.Friend = _findableFriend
                        .FindById(createdLoan.FriendId);

                    createdLoan.BorrowedGame = _gameService
                        .FindById(createdLoan.GameId);

                    createdLoan = _loanService
                        .Create(createdLoan);

                    if (createdLoan == null)
                    {
                        unitOfWork.Rollback();
                        return null;
                    }

                    unitOfWork.Save();
                    unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    return null;
                }
            }

            return _mapper.Map<LoanViewModel>(createdLoan);
        }

        public LoanViewModel UpdateReturnDate(LoanViewModel viewModel)
        {
            Loan updatedLoan;

            using (var unitOfWork = _unitOfWorkFactory
                .StartUnitOfWork(true))
            {
                try
                {
                    updatedLoan = _loanService.UpdateReturnDate(
                        viewModel.Id,
                        viewModel.ReturnDate.GetValueOrDefault());

                    if (updatedLoan == null)
                    {
                        unitOfWork.Rollback();
                        return null;
                    }

                    unitOfWork.Save();
                    unitOfWork.Commit();
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    return null;
                }
            }

            return _mapper.Map<LoanViewModel>(updatedLoan);
        }

        public void Delete(string entityId) =>
            _deletableAppService.Delete(entityId);

        public LoanViewModel FindById(string id) =>
            _findableIdAppService.FindById(id);

        public IEnumerable<LoanViewModel> LoadAll() =>
            _loadAllAppService.LoadAll();
    }
}