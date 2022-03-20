using AutoMapper;
using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests.Commands;
using ExpenseTracker.Application.Contracts.Persistence;
using ExpenseTracker.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Handlers.Commands
{
    public class DeleteExpenseCategoryCommandHandler : IRequestHandler<DeleteExpenseCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExpenseCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var expenseCategory = await _unitOfWork.ExpenseCategoryRepository.Get(request.Id);

            if (expenseCategory == null)
                throw new NotFoundException(nameof(ExpenseCategory), request.Id);

            await _unitOfWork.ExpenseCategoryRepository.Delete(expenseCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
