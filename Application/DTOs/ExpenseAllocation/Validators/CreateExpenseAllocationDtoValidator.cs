﻿using FluentValidation;
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DTOs.ExpenseAllocation.Validators
{
    public class CreateExpenseAllocationDtoValidator : AbstractValidator<CreateExpenseAllocationDto>
    {
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public CreateExpenseAllocationDtoValidator(IExpenseCategoryRepository expenseCategoryRepository)
        {
            _expenseCategoryRepository = expenseCategoryRepository;

            RuleFor(p => p.ExpenseCategoryId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var expenseCategoryExists = await _expenseCategoryRepository.Exists(id);
                    return expenseCategoryExists;
                })
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}