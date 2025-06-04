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
    public class PostRepository: RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(AppDBContext context) : base(context) { }

        public async Task<List<Post>> GetAllPostsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Post> GetPostAsync(string id, bool trackChanges)
        {
            return await FindByCondition(p => p.Id == Guid.Parse(id), trackChanges)
            .Include(p => p.User)
            .FirstOrDefaultAsync();          
        }
        public void CreatePost(Post post)
        {
            Create(post);
        }

        public void DeletePost(Post post)
        {
            Delete(post);
        }

        public void UpdatePost(Post post)
        {
            Update(post);
        }

        public async Task<List<Post>> GetPostsByUserId(string userId, bool trackChanges)
        {
            return await FindByCondition(p => p.UserId == userId,trackChanges)
            .ToListAsync();
        }
    }
}