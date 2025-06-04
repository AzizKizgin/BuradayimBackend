using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Service.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IPostService PostService { get; }
    }
}