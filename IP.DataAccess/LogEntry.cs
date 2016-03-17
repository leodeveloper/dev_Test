using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IP.DataAccess
{
    public class LogEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public string ApplicationName { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
