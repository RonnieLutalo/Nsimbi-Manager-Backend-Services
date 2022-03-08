using AutoMapper;
using Application.DTOs.ExpenseAllocation.Validators;
using Application.Exceptions;
using Application.Features.ExpenseAllocations.Requests.Commands;
using Application.Features.ExpenseCategories.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.LeaveAllocations.Handlers.Commands
{
    public class UpdateExpenseAllocationCommandHandler : IRequestHandler<UpdateExpenseAllocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExpenseAllocationCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExpenseAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExpenseAllocationDtoValidator(_unitOfWork.ExpenseCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.ExpenseAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var expenseAllocation = await _unitOfWork.ExpenseAllocationRepository.Get(request.ExpenseAllocationDto.Id);

            if (expenseAllocation is null)
                throw new NotFoundException(nameof(expenseAllocation), request.ExpenseAllocationDto.Id);

            _mapper.Map(request.ExpenseAllocationDto, expenseAllocation);

            await _unitOfWork.ExpenseAllocationRepository.Update(expenseAllocation);
            await _unitOfWork.Save();
            return Unit.Value;
        }
    }
}
