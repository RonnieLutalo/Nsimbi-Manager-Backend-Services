using Application.Contracts.Identity;
using Application.Models.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
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
