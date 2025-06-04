using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Service.Contracts;

namespace BuradayimBackend.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public ServiceManager(IUserService userService, IPostService postService)
        {
            _userService = userService;
            _postService = postService;
        }
        public IUserService UserService => _userService;
        public IPostService PostService => _postService;
    }
}