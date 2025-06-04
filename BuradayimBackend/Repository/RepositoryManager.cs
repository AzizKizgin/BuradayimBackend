using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Data;
using BuradayimBackend.Repository.Contracts;

namespace BuradayimBackend.Repository
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly AppDBContext _context;
        private readonly IUserRepository _user;
        private readonly IPostRepository _post;

        public RepositoryManager(AppDBContext context, IUserRepository userRepository, IPostRepository postRepository)
        {
            _context = context;
            _user = userRepository;
            _post = postRepository;
        }

        public IUserRepository User => _user;
        public IPostRepository Post => _post;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}