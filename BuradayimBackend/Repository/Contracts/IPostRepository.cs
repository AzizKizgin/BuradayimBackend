using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Models;

namespace BuradayimBackend.Repository.Contracts
{
    public interface IPostRepository: IRepositoryBase<Post>
    {
        Task<List<Post>> GetAllPostsAsync(bool trackChanges);
        Task<Post> GetPostAsync(string id, bool trackChanges);
        Task<List<Post>> GetPostsByUserId(string userId, bool trackChanges);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}