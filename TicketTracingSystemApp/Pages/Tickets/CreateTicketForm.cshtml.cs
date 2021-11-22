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
    public class CreateTicketFormModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        public CreateTicketFormModel(CustomerRepository customerRepository)
        {
            cRepo = customerRepository;
        }
        
        [BindProperty]
        public Ticket TicketInput { get; set; }

        
        public void OnGet()
        {
            var list = cRepo.List();
        }

        public void OnPostSave()
        {

        }
    }
}
