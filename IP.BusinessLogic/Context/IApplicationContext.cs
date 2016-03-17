using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.BusinessLogic.Context
{
    public interface IApplicationContext
    {
        string ApplicationName { get; }
    }
}
