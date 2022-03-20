using ExpenseTracker.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<RegularAppUser>> GetRegularAppUsers();
        Task<RegularAppUser> GetRegularAppUser(string userId);
    }
}
