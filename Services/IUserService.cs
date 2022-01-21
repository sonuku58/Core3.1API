using StudentAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Services
{
    public interface IUserService
    {
        UserDetail Authenticate(string username, string password);
        IEnumerable<UserDetail> GetAll();
       
    }
}
