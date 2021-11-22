using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketTracingSystemApp.Models
{
    public class Ticket
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Subject { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public Manager Maneger { get; set; }
        public short LevelOfDifficulty { get; set; }
        public short Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Statu { get; set; }
    }
}
