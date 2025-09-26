using Clinic.Application.Interfaces;
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
        private readonly ClinicDbContext _db;
        public UserRepository(ClinicDbContext dbContext)
        {
            _db = dbContext;
        }
        public async Task AddUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
