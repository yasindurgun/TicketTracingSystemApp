using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTracingSystemApp.Models;
using TicketTracingSystemApp.Repositories;

namespace TicketTracingSystemApp.Services
{
    public class WaitingForAssignmentService
    {
        TicketRepository _ticketRepository;
        public WaitingForAssignmentService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public string EmployeeId { get; set; }
        public List<Ticket> Tickets { get; set; }
        public void CheckForRules(string id)
        {
            int count = 0;
            var now = DateTime.Now.Day;
            var last = Convert.ToInt32(DateTime.Now.AddDays(30));
            var alongAMounth = last - now;
            //Tickets = _ticketRepository.List();
            var emp = _ticketRepository.Find(id);

            foreach (var item in Tickets)
            {
                if (item.EmployeeId == id && item.Priority=="Zor")
                {
                    count++;
                    if (alongAMounth<32 && count<4)
                    {
                        
                    }
                    else
                    {
                        throw new Exception("1 ay içinde bir çalışana en fazla 3 iş atanabilir.");
                    }
                }
            }
        }
    }
}
