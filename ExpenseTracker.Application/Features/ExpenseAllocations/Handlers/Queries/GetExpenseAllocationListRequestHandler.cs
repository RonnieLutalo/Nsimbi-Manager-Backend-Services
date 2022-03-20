﻿using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.Features.ExpenseAllocations.Requests.Queries;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests;
using ExpenseTracker.Application.Features.ExpenseCategories.Requests.Queries;
using ExpenseTracker.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpenseTracker.Domain;
using ExpenseTracker.Application.Contracts.Identity;
using Microsoft.AspNetCore.Http;
using ExpenseTracker.Application.Constants;

namespace ExpenseTracker.Application.Features.ExpenseAllocations.Handlers.Queries
{
    public class GetExpenseAllocationListRequestHandler : IRequestHandler<GetExpenseAllocationListRequest, List<ExpenseAllocationListDto>>
    {
        private readonly IExpenseAllocationRepository _expenseAllocationRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetExpenseAllocationListRequestHandler(IExpenseAllocationRepository expenseAllocationRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _expenseAllocationRepository = expenseAllocationRepository;
            _mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._userService = userService;
        }

        public async Task<List<ExpenseAllocationListDto>> Handle(GetExpenseAllocationListRequest request, CancellationToken cancellationToken)
        {
            var expenseAllocations = new List<ExpenseAllocation>();
            var requests = new List<ExpenseAllocationListDto>();

            if (request.IsLoggedInUser)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                    q => q.Type == CustomClaimTypes.Uid)?.Value;
                expenseAllocations = await _expenseAllocationRepository.GetExpenseAllocationsWithDetails(userId);

                var regularAppUser = await _userService.GetRegularAppUser(userId);
                requests = _mapper.Map<List<ExpenseAllocationListDto>>(expenseAllocations);
                foreach (var req in requests)
                {
                    req.RegularAppUser = regularAppUser;
                }
            }
            else
            {
                expenseAllocations = await _expenseAllocationRepository.GetExpenseAllocationsWithDetails();
                requests = _mapper.Map<List<ExpenseAllocationListDto>>(expenseAllocations);
                foreach (var req in requests)
                {
                    req.RegularAppUser = await _userService.GetRegularAppUser(req.RegularAppUserAccountHolderId);
                }
            }

            return requests;

            
        }
    }
}