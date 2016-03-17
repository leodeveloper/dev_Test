using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.Logging
{
    public interface ILogger
    {
        void LogException(String message, Exception e);
        void LogException(Exception e);
        void LogEvent(String message);
    }
}
