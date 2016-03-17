using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IP.DataAccess
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }

        public Guid OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }
        
        // The JavaScriptSerializer ignores this field.
        // But proxy types dont inherit it!!
        // [ScriptIgnore]
        public virtual ICollection<LogEntry> LogEntries { get; set; }
    }
}
