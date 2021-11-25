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
    public class SetTechDetailsPageModel : PageModel
    {
        private readonly TicketRepository ticketRepo;
        private readonly CustomerRepository cRepo;
        public SetTechDetailsPageModel(TicketRepository ticketRepository, CustomerRepository customerRepository)
        {
            ticketRepo = ticketRepository;
            cRepo = customerRepository;
        }
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public Ticket Ticket { get; set; }
        public Customer Customer { get; set; }

        [BindProperty]
        public string levelOfdiff { get; set; }
        [BindProperty]
        public string priority { get; set; }
        public string cName { get; set; }
        public void OnGet(string? id)
        {
            this.Id = id;
            Ticket = ticketRepo.Find(Id);
            Customer = cRepo.Find(Ticket.CustomerId);
            cName = Customer.Name;
        }

        public void OnPostSetTechDetails(string id, string customRadio, string customRadioInline)
        {
                this.Id = id;
                Ticket = ticketRepo.Find(Id);
                Customer = cRepo.Find(Ticket.CustomerId);
                levelOfdiff = customRadio;
                priority = customRadioInline;
                Ticket.LevelOfDifficulty = levelOfdiff;
                Ticket.Priority = priority;
                Ticket.Statu = "WaitingForAssignment";
                ticketRepo.Update(Ticket);
        }
    }
}
