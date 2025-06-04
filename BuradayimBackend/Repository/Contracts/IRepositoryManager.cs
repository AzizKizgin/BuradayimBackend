using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuradayimBackend.Repository.Contracts
{
    public interface IRepositoryManager
    {
        IUserRepository User { get;  }
        IPostRepository Post { get;  }
        Task SaveAsync();
    }
}