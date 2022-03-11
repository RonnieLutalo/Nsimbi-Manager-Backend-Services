using AutoMapper;
using Application.DTOs;
using Application.DTOs.ExpenseAllocation;
using Application.DTOs.ExpenseCategory;
using Domain;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ExpenseAllocation Mappings
            CreateMap<ExpenseAllocation, ExpenseAllocationDto>().ReverseMap();
            CreateMap<ExpenseAllocation, ExpenseAllocationListDto>().ReverseMap();
            CreateMap<ExpenseAllocation, CreateExpenseAllocationtDto>().ReverseMap();
            CreateMap<ExpenseAllocation, UpdateExpenseAllocationDto>().ReverseMap();
            #endregion ExpenseAllocation

            CreateMap<ExpenseCategory, ExpenseCategoryDto>().ReverseMap();
            CreateMap<ExpenseCategory, CreateExpenseCategoryDto>().ReverseMap();
        }
    }
}
