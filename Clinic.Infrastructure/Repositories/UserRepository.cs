using Clinic.Application.Interfaces.Repository;
using Clinic.Domain.Entities;
using Clinic.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task AddUserAsync(ApplicationUser user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(string userId)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<ApplicationUser?> GetUserByUsernameAsync(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
