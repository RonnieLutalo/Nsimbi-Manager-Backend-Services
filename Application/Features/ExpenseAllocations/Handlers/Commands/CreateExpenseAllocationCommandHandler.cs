using AutoMapper;
using Application.DTOs.ExpenseAllocation.Validators;
using Application.Exceptions;
using Application.Features.ExpenseAllocations.Requests.Commands;
using Application.Features.ExpenseCategories.Requests.Commands;
using Application.Contracts.Persistence;
using Application.Responses;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Application.Constants;

namespace Application.Features.ExpenseAllocations.Handlers.Commands
{
    public class CreateExpenseAllocationCommandHandler : IRequestHandler<CreateExpenseAllocationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public CreateExpenseAllocationCommandHandler(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateExpenseAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateExpenseAllocationDtoValidator(_unitOfWork.ExpenseCategoryRepository);
            var validationResult = await validator.ValidateAsync(request.ExpenseAllocationDto);
            var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
            
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var expenseAllocation = _mapper.Map<ExpenseAllocation>(request.ExpenseAllocationDto);
                expenseAllocation.RegularAppUserAccountHolderId = userId;
                expenseAllocation = await _unitOfWork.ExpenseAllocationRepository.Add(expenseAllocation);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Request Created Successfully";
                response.Id = expenseAllocation.Id;
            }
            
            return response;
        }
    }
}
