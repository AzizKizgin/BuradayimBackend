using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Dtos.User;
using BuradayimBackend.Models;

namespace BuradayimBackend.Service.Contracts
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(string id);
        Task<UserDto> Login(LoginDto loginInfo);
        Task Logout();
        Task<UserDto> Register(RegisterDto registerInfo);
        Task DeleteUser(string id);
        string GenerateToken(User user);
        Task ChangePassword(string id, ChangePasswordDto changePasswordInfo);
        Task<List<UserDto>> SearchUsers(string username);
        Task<UserDto> UpdateUser(string id, UpdateUserDto updateUserInfo);
    }
}