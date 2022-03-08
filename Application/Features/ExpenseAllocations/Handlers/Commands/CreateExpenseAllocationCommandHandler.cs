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
using Application.Responses;
using System.Linq;
using Application.Contracts.Identity;

namespace Application.Features.ExpenseAllocations.Handlers.Commands
{
    public class CreateExpenseAllocationCommandHandler : IRequestHandler<CreateExpenseAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CreateExpenseAllocationCommandHandler(
           IUnitOfWork unitOfWork,
            IUserService userService,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExpenseAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExpenseAllocationDtoValidator(_unitOfWork.ExpenseCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.ExpenseAllocationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Allocations Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var expenseCategory = await _unitOfWork.ExpenseCategoryRepository.Get(request.ExpenseAllocationDto.ExpenseCategoryId);
                var employees = await _userService.GetEmployees();
                var period = DateTime.Now.Year;
                var allocations = new List<ExpenseAllocation>();
                foreach (var emp in employees)
                {
                    if (await _unitOfWork.ExpenseAllocationRepository.AllocationExists(emp.Id, expenseCategory.Id, period))
                        continue;
                    allocations.Add(new ExpenseAllocation
                    {
                        EmployeeId = emp.Id,
                        LeaveTypeId = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period = period
                    });
                }

                await _unitOfWork.ExpenseAllocationRepository.AddAllocations(allocations);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Allocations Successful";
            }


            return response;
        }
    }
}
