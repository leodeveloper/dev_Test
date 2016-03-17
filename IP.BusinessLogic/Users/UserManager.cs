using IP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.BusinessLogic.Users
{
    public class UserManager
    {
        private readonly UserService _userService;
        public UserManager(UserService userService)
        {
            _userService = userService;
        }
        public User CreateUser()
        {
            return _userService.CreateUser();
        }
    }
}
