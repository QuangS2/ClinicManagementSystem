using Clinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetUserByUsernameAsync(string username);
        Task<ApplicationUser?> GetUserByIdAsync (string userId);
        Task AddUserAsync(ApplicationUser user);
        Task SaveChangesAsync();
        //update user
        Task UpdateUserAsync(ApplicationUser user);
    }
}
