using AutoMapper;
using ExpenseTracker.Application.Contracts.Identity;
using ExpenseTracker.Application.Models.Identity;
using ExpenseTracker.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegularAppUser> GetRegularAppUser(string userId)
        {
            var regularAppUser = await _userManager.FindByIdAsync(userId);
            return new RegularAppUser
            {
                Email = regularAppUser.Email,
                Id = regularAppUser.Id,
                Firstname = regularAppUser.FirstName,
                Lastname = regularAppUser.LastName
            };
        }

        public async Task<List<RegularAppUser>> GetRegularAppUsers()
        {
            var regularAppUsers = await _userManager.GetUsersInRoleAsync("RegularAppUser");
            return regularAppUsers.Select(q => new RegularAppUser { 
                Id = q.Id,
                Email = q.Email,
                Firstname = q.FirstName,
                Lastname = q.LastName
            }).ToList();
        }
    }
}
