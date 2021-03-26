using MvvmCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test2021Library.Models;

namespace Test2021Library.Helper
{
    public class UserService : IUserService
    {
        private readonly ISqliteDataService _sqliteDataService;
        public UserService()
        {
            _sqliteDataService = Mvx.IoCProvider.Resolve<ISqliteDataService>();
        }

        //Get All Users
        public List<UsersModel> GetAllUsers()
        {
            return _sqliteDataService.ReadList<UsersModel>();
        }

        // Get User
        public UsersModel GetUser(string userName)
        {
            return _sqliteDataService.ReadFirst<UsersModel>(x => x.UserName == userName);
        }

        // Insert User
        public void InsertUser(UsersModel usersModel)
        {
            _sqliteDataService.Insert(usersModel, typeof(UsersModel));
        }
    }
}
