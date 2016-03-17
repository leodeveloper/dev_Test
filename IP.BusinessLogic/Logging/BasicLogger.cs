using IP.BusinessLogic.Context;
using IP.DataAccess;
using IP.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.BusinessLogic.Logging
{
    public class BasicLogger : AbstractSqlLogger
    {
        private readonly IUserContext _userContext;
        private readonly IApplicationContext _applicationContext;
        public BasicLogger(IUserContext userContext, IApplicationContext applicationContext)
        {
            _userContext = userContext;
            _applicationContext = applicationContext;
        }
        public override void LogException(string message, Exception e)
        {
            Log(message, String.Format("Message: {0}\nStacktrace: {1}", e.Message, e.StackTrace));
        }

        private void Log(string message, string data)
        {
            LogToSql(_userContext.UserId, _userContext.OrganisationId, _applicationContext.ApplicationName, message, data);
        }

        public override void LogException(Exception e)
        {
            LogException("An Error Occurred", e);
        }

        public override void LogEvent(string message)
        {
            Log(message, Environment.StackTrace);
        }
    }
}
