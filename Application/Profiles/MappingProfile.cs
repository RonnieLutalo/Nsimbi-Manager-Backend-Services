using AutoMapper;
using Application.DTOs;
using Application.DTOs.ExpenseCategory;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Expense Category mappings
            CreateMap<ExpenseCategory, ExpenseCategoryDto>().ReverseMap();
            CreateMap<ExpenseCategory, CreateExpenseCategoryDto>().ReverseMap();
        }
    }
}
