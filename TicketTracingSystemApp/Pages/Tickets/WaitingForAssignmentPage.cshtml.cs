using System;
using System.Collections.Generic;
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
    public class WaitingForAssignmentPageModel : PageModel
    {
        TicketRepository _ticketRepository;
        EmployeeRepository _employeeRepository;
        Services.WaitingForAssignmentService _service;
        public WaitingForAssignmentPageModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository, WaitingForAssignmentService service)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
            _service = service;
        }
        //public List<SelectListItem> SelectListItems = new List<SelectListItem>();
        public string Id { get; set; }
        [BindProperty]
        public Ticket TicketInput { get; set; }
        [BindProperty]
        public List<Ticket> Tickets { get; set; }
        [BindProperty]
        public List<Employee> Employees { get; set; }
        [BindProperty]
        public string SelectedList { get; set; }
        public List<SelectListItem> Options { get; set; }
        public void OnGet()
        {
            Tickets = _ticketRepository.List();
            Employees = _employeeRepository.List();
            Options = Employees.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Name
                                  }).ToList();
        }

        public void OnPostSave(string id)
        {
            this.Id = id.ToString();
            TicketInput = _ticketRepository.Find(Id);
            var emp = _employeeRepository.Find(SelectedList);
            TicketInput.EmployeeId = emp.Id;
            TicketInput.Statu = "Assigned";
            TicketInput.AssignDate = DateTime.Now;
            _ticketRepository.Update(TicketInput);
            OnGet();
        }
    }
}
