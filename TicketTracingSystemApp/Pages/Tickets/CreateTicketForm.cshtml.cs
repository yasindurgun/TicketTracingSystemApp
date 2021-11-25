using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketTracingSystemApp.Models;
using TicketTracingSystemApp.Repositories;
using TicketTracingSystemApp.Services;

namespace TicketTracingSystemApp.Pages.Tickets
{
    public class CreateTicketFormModel : PageModel
    {
        private readonly CustomerRepository cRepo;
        private readonly TicketCreateService tcService;
        private readonly EmailSendService emailSendService;
        public CreateTicketFormModel(CustomerRepository customerRepository, TicketCreateService service, EmailSendService mailService)
        {
            cRepo = customerRepository;
            tcService = service;
            emailSendService = mailService;
        }
        
        public List<SelectListItem> SelectListItems = new List<SelectListItem>();
        [BindProperty]
        public Ticket TicketInput { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Þirket bilgisi boþ geçilemez")]
        public string SelectedList { get; set; }
        //public List<Customer> customers;
        //public List<SelectListItem> Customers;
        [BindProperty]
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<SelectListItem> Options { get; set; }
        //public SelectList list { get; set; }
        public void OnGet()
        {
            Customers =  cRepo.List();

            Options = Customers.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();

        }

        public void OnPostSave()
        {
            
            var email = cRepo.Find(SelectedList);
            if (ModelState.IsValid)
            {
                tcService.Save(TicketInput, SelectedList, "Open");
                emailSendService.SendEmail("bitirmeprojesi55@gmail.com",$"{email.Email}",$"Ticket takip no:{TicketInput.Id}","Yeni ticket açýldý.");
                ViewData["Message"] = "Kayýt baþarýlýdýr";
            }
            OnGet();
        }
    }
}
