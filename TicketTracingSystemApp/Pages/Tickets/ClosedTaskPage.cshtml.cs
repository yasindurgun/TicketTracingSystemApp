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
    public class ClosedTaskPageModel : PageModel
    {
        TicketRepository _ticketRepository;
        EmployeeRepository _employeeRepository;
        public ClosedTaskPageModel(TicketRepository ticketRepository, EmployeeRepository employeeRepository)
        {
            _ticketRepository = ticketRepository;
            _employeeRepository = employeeRepository;
        }
        public Employee emp { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        [BindProperty]
        public List<string> EmployesNames { get; set; } = new List<string>();
        public void OnGet(string? id)
        {
            Tickets = _ticketRepository.List();
            Tickets = Tickets.Where(x => x.Statu == "Closed").ToList();
            var employees = Tickets.Where(x => x.Statu == "Closed")
                .Select(y => y.EmployeeId);



            foreach (var item in employees)
            {
                emp = _employeeRepository.Find(item);
                EmployesNames.Add(emp.Name);
            }
        }
    }
}
