using IP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccess
{
    /// <summary>
    /// This implementation is in IP.DataAccess because *everything* needs to access logging
    /// but not everything wants to be dependent on DataAccess
    /// </summary>
    public abstract class AbstractSqlLogger : ILogger
    {

        protected void LogToSql(int userId, int organisationId, string applicationName, string message, string data)
        {
            using (var ctx = new IPContext())
            {
                ctx.LogEntries.Add(new LogEntry
                {
                    UserId = userId,
                    OrganisationId = organisationId,
                    ApplicationName = applicationName,
                    Message = message,
                    Data = data
                });
                ctx.SaveChanges();
            }
        }


        public abstract void LogException(string message, Exception e);

        public abstract void LogException(Exception e);

        public abstract void LogEvent(string message);
    }
}
