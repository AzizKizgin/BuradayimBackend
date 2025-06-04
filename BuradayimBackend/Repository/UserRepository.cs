using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Data;
using BuradayimBackend.Models;
using BuradayimBackend.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BuradayimBackend.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDBContext context) : base(context) { }

        public async Task<List<User>> GetAllUsersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<User> GetUserAsync(string id, bool trackChanges)
        {
            return await FindByCondition(u => u.Id == id, trackChanges)
            .Include(u => u.Posts)
            .FirstOrDefaultAsync();
        }
    }
}