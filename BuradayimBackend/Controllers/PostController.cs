using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BuradayimBackend.Dtos;
using BuradayimBackend.Dtos.Post;
using BuradayimBackend.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuradayimBackend.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public PostController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostDto createPostDto)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return Unauthorized();
                }

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return Unauthorized("User ID not found in token.");
                }
                createPostDto.UserId = userId;
                var post = await _serviceManager.PostService.CreatePost(createPostDto);
                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] string id)
        {
            try
            {
                var post = await _serviceManager.PostService.GetPostById(id);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (post.User.Id != userId)
                {
                    return Forbid();
                }
                await _serviceManager.PostService.DeletePost(post.Id);
                var message = new SuccessMessage { Message = "Post Deleted" };
                return Ok(message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost([FromRoute] string id)
        {
            try
            {
                var post = await _serviceManager.PostService.GetPostById(id);
                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserPost([FromRoute] string id)
        {
            try
            {
                var post = await _serviceManager.PostService.GetPostsByUserId(id);
                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdatePost([FromRoute] string id, UpdatePostDto updatePostDto)
        {
            try
            {
                var post = await _serviceManager.PostService.UpdatePost(id, updatePostDto);
                return Ok(post);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _serviceManager.PostService.GetPosts();
                return Ok(posts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}