using IP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccessTests
{
    class TestDatabaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<IPContext>
    {
        protected override void Seed(IPContext context)
        {
            context.Users.Add(new User()
            {
                UserId = 1
            });
            context.SaveChanges();
                
        }
    }
}
