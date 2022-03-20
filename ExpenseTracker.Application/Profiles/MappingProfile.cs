using AutoMapper;
using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.DTOs.ExpenseAllocation;
using ExpenseTracker.Application.DTOs.ExpenseCategory;
using ExpenseTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ExpenseAllocation Mappings
            CreateMap<ExpenseAllocation, ExpenseAllocationDto>().ReverseMap();
            CreateMap<ExpenseAllocation, ExpenseAllocationListDto>()
                .ForMember(dest => dest.ExpenseCategory, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            CreateMap<ExpenseAllocation, CreateExpenseAllocationDto>().ReverseMap();
            CreateMap<ExpenseAllocation, UpdateExpenseAllocationDto>().ReverseMap();
            #endregion ExpenseAllocation

            CreateMap<ExpenseCategory, ExpenseCategoryDto>().ReverseMap();
            CreateMap<ExpenseCategory, CreateExpenseCategoryDto>().ReverseMap();
        }
    }
}
