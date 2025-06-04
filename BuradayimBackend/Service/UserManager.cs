using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuradayimBackend.Dtos.User;
using BuradayimBackend.Models;
using BuradayimBackend.Repository.Contracts;
using BuradayimBackend.Service.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BuradayimBackend.Service
{
    public class UserManager : IUserService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserManager(
            IRepositoryManager manager,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService)
        {
            _manager = manager;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task ChangePassword(string id, ChangePasswordDto changePasswordInfo)
        {
            var user = await _manager.User.GetUserAsync(id, true) ?? throw new Exception("User not found");
            await _userManager.ChangePasswordAsync(user, changePasswordInfo.OldPassword, changePasswordInfo.NewPassword);
        }

        public async Task DeleteUser(string id)
        {
            var user = await _manager.User.GetUserAsync(id, true) ?? throw new Exception("User not found");
            await _userManager.DeleteAsync(user);
            await _manager.SaveAsync();
        }

        public string GenerateToken(User user)
        {
            return _tokenService.GenerateToken(user);
        }

        public async Task<UserDto> GetUserById(string id)
        {
            var user = await _manager.User.GetUserAsync(id, true) ?? throw new Exception("User not found");
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> Login(LoginDto loginInfo)
        {
            var user = await _manager.User.GetUserByEmailAsync(loginInfo.Email, true) ?? throw new Exception("User not found");
            var result = await _signInManager.PasswordSignInAsync(user, loginInfo.Password, false, false);
            if (!result.Succeeded)
            {
                throw new Exception("User not couldn't login");
            }
            return _mapper.Map<UserDto>(user);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> Register(RegisterDto registerInfo)
        {
            var user = _mapper.Map<User>(registerInfo);
            var result = await _userManager.CreateAsync(user, registerInfo.Password);
            if (!result.Succeeded)
            {
                throw new Exception("User not couldn't register");
            }
            var newUser = await _manager.User.GetUserByEmailAsync(registerInfo.Email, true);
            return _mapper.Map<UserDto>(newUser);
        }

        public async Task<List<UserDto>> SearchUsers(string username)
        {
            var users = await _manager.User.SearchUsersByName(username, false);
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> UpdateUser(string id, UpdateUserDto updateUserInfo)
        {
            var user = await _manager.User.GetUserAsync(id, true) ?? throw new Exception("User not found");
            user.About = updateUserInfo.About;
            user.ProfilePicture = Convert.FromBase64String(updateUserInfo.ProfilePicture);
            await _userManager.UpdateAsync(user);
            await _manager.SaveAsync();
            return _mapper.Map<UserDto>(user);
        }
    }
}