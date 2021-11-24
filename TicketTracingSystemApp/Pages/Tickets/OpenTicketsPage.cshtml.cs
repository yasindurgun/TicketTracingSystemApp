using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketTracingSystemApp.Models;
using TicketTracingSystemApp.Repositories;

namespace TicketTracingSystemApp.Pages.Tickets
{
    
  
    public class OpenTicketsPageModel : PageModel
    {
        private readonly TicketRepository ticketRepo;
        public OpenTicketsPageModel(TicketRepository ticketRepository)
        {
            ticketRepo = ticketRepository;
        }
        public List<Ticket> Tickets { get; set; }

        public void OnGet()
        {

            Tickets = ticketRepo.List();
        }

    }
}
