using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuradayimBackend.Models;

namespace BuradayimBackend.Service.Contracts
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}