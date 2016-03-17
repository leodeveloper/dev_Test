using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccess
{
    public class UserService
    {
        public User CreateUser()
        {
            var user = new User();
            using (var ctx = new IPContext())
            {
                ctx.Users.Add(user);
                ctx.SaveChanges();
            }
            return user;
        }
    }
}
