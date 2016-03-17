using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccess
{
    public class Organisation
    {
        [Key]
        public Guid OrganisationId { get; set; }
        public string OrganisationName { get; set; }
    }
}
