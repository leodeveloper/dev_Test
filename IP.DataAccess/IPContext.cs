using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccess
{
    public class IPContext : DbContext
    {
        public DbSet<LogEntry> LogEntries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
