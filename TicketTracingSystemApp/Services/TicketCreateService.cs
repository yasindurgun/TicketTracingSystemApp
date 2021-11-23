using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTracingSystemApp.Models;
using TicketTracingSystemApp.Repositories;

namespace TicketTracingSystemApp.Services
{
    public class TicketCreateService
    {
        TicketRepository _ticketRepository;
        public TicketCreateService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Save(Ticket ticket, string customerId)
        {
            if (String.IsNullOrEmpty(ticket.Subject))
            {
                throw new Exception("Subject alanı boş geçilemez.");
            }

            if (ticket.Subject.Length>50)
            {
                throw new Exception("Subject alanı en fazla 50 karakter olabilir.");
            }
            if (String.IsNullOrEmpty(ticket.Description))
            {
                throw new Exception("Subject alanı boş geçilemez.");
            }

            if (ticket.Description.Length > 300)
            {
                throw new Exception("Description alanı en fazla 300 karakter olabilir.");
            }
            ticket.CustomerId= customerId;
            _ticketRepository.Add(ticket);
        }
    }
}
