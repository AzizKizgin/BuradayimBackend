using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuradayimBackend.Dtos.Post;
using BuradayimBackend.Models;
using BuradayimBackend.Repository.Contracts;
using BuradayimBackend.Service.Contracts;

namespace BuradayimBackend.Service
{
    public class PostManager : IPostService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public PostManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<PostDto> CreatePost(CreatePostDto createPostInfo)
        {
            var newPost = _mapper.Map<Post>(createPostInfo);
            _manager.Post.CreatePost(newPost);
            await _manager.SaveAsync();
            return _mapper.Map<PostDto>(newPost);
        }

        public async Task DeletePost(string id)
        {
            var post = await _manager.Post.GetPostAsync(id, true);
            _manager.Post.DeletePost(post);
            await _manager.SaveAsync();
        }

        public async Task<PostDto> GetPostById(string id)
        {
            var post = await _manager.Post.GetPostAsync(id, false);
            return _mapper.Map<PostDto>(post);   
        }

        public async Task<List<PostDto>> GetPosts()
        {
            var posts = await _manager.Post.GetAllPostsAsync(false);
            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<List<PostDto>> GetPostsByUserId(string id)
        {
            var post = await _manager.Post.GetPostsByUserId(id, false);
            return _mapper.Map<List<PostDto>>(post);
        }

        public async Task<PostDto> UpdatePost(string id, UpdatePostDto updatePostInfo)
        {
            var post = await _manager.Post.GetPostAsync(id, true);
            post.Title = updatePostInfo.Title;
            post.Content = updatePostInfo.Content;
            post.Latitude = updatePostInfo.Latitude;
            post.Longitude = updatePostInfo.Longitude;
            post.Images = updatePostInfo.Images.Select(base64 => Convert.FromBase64String(base64)).ToList();
            _manager.Post.UpdatePost(post);
            await _manager.SaveAsync();
            return _mapper.Map<PostDto>(post);
        }
    }
}