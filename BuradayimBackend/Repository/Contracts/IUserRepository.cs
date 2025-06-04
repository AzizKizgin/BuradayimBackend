using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Models;

namespace BuradayimBackend.Repository.Contracts
{
    public interface IUserRepository: IRepositoryBase<User>
    {
        Task<List<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserAsync(string id, bool trackChanges);
    }
}