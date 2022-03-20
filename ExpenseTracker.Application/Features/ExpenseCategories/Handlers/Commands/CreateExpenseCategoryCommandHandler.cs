using AutoMapper;
using ExpenseTracker.Application.DTOs.ExpenseCategory.Validators;
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
using ExpenseTracker.Application.Responses;
using System.Linq;

namespace ExpenseTracker.Application.Features.ExpenseCategories.Handlers.Commands
{
    public class CreateExpenseCategoryCommandHandler : IRequestHandler<CreateExpenseCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExpenseCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExpenseCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ExpenseCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var expenseCategory = _mapper.Map<ExpenseCategory>(request.ExpenseCategoryDto);

                expenseCategory = await _unitOfWork.ExpenseCategoryRepository.Add(expenseCategory);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = expenseCategory.Id;
            }

            return response;
        }
    }
}
