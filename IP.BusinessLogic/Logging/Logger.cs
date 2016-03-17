using IP.BusinessLogic.Context;
using IP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.Logging
{
    public class Logger :  AbstractSqlLogger
    {

        #region private members
        private readonly IUserContext _userContext;
        private readonly IApplicationContext _applicationContext;
        #endregion

        #region public methods
        public Logger(IUserContext userContext, IApplicationContext applicationContext)
        {
            _userContext = userContext;
            _applicationContext = applicationContext;
        }
        public async override void LogException(String message, Exception e)
        {
           await  Log(message, $"{e.Message},{e.StackTrace}");
        }
        public async override void LogException(Exception e)
        {
            await Task.Factory.StartNew(() => LogException("An Error Occurred", e));
        }
        public async override void LogEvent(String message)
        {
            await Log(message, Environment.StackTrace);
        }
        #endregion

        #region private methods
        private async Task Log(string message, string data)
        {
            await Task.Factory.StartNew(() => LogToSql(_userContext.UserId, _userContext.OrganisationId, _applicationContext.ApplicationName, message, data));

        }
        #endregion
    }
}
