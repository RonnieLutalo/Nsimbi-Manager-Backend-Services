using AutoMapper;
using Application.DTOs;
using Application.DTOs.ExpenseCategory;
using Application.Features.LeaveTypes.Requests;
using Application.Features.ExpenseCategories.Requests.Queries;
using Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetExpenseCategoryListRequestHandler : IRequestHandler<GetExpenseCategoryListRequest, List<ExpenseCategoryDto>>
    {
        private readonly IExpenseCategoryRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetExpenseCategoryListRequestHandler(IExpenseCategoryRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseCategoryDto>> Handle(GetExpenseCategoryListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _leaveTypeRepository.GetAll();
            return _mapper.Map<List<ExpenseCategoryDto>>(leaveTypes);
        }
    }
}
