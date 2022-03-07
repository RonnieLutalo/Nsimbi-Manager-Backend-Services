using AutoMapper;
using Application.DTOs.ExpenseCategory.Validators;
using Application.Exceptions;
using Application.Features.ExpenseCategories.Requests.Commands;
using Application.Contracts.Persistence;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ExpenseCategories.Handlers.Commands
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExpenseCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExpenseCategoryDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var expenseCategory = await _unitOfWork.ExpenseCategoryRepository.Get(request.ExpenseCategoryDto.Id);

            if (expenseCategory is null)
                throw new NotFoundException(nameof(expenseCategory), request.ExpenseCategoryDto.Id);

            _mapper.Map(request.ExpenseCategoryDto, expenseCategory);

            await _unitOfWork.ExpenseCategoryRepository.Update(expenseCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
