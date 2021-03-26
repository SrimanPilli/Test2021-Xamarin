using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2021Library.Models;

namespace Test2021Library.Helper
{
    public interface IUserService
    {
        void InsertUser(UsersModel user);
        UsersModel GetUser(string userName);
        List<UsersModel> GetAllUsers();
    }
}
