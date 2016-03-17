using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.BusinessLogic.Context
{
    public interface IUserContext
    {
        int UserId { get; }
        int OrganisationId { get; }
    }
}
