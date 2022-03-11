using AutoMapper;
using Application.Exceptions;
using Application.Features.ExpenseAllocations.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ExpenseAllocations.Handlers.Commands
{
    public class DeleteExpenseAllocationCommandHandler : IRequestHandler<DeleteExpenseAllocationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExpenseAllocationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExpenseAllocationCommand request, CancellationToken cancellationToken)
        {
            var expenseAllocation = await _unitOfWork.ExpenseAllocationRepository.Get(request.Id);

            if (expenseAllocation == null)
                throw new NotFoundException(nameof(ExpenseAllocation), request.Id);

            await _unitOfWork.ExpenseAllocationRepository.Delete(expenseAllocation);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
