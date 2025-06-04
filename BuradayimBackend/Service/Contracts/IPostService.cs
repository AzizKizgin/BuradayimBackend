using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Dtos.Post;
using BuradayimBackend.Models;

namespace BuradayimBackend.Service.Contracts
{
    public interface IPostService
    {
        Task<PostDto> CreatePost(CreatePostDto createPostInfo);
        Task<List<PostDto>> GetPosts();
        Task<List<PostDto>> GetPostsByUserId(string id);
        Task<PostDto> GetPostById(string id);
        Task<PostDto> UpdatePost(string id, UpdatePostDto updatePostInfo);
        Task DeletePost(string id);
    }
}