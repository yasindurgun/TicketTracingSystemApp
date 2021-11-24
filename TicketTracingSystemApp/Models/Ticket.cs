﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketTracingSystemApp.Models
{
    public class Ticket
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required(ErrorMessage = "Subject boş geçilemez")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Description boş geçilemez")]
        public string Description { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ManagerId { get; set; }
        public Manager Maneger { get; set; }
        public string LevelOfDifficulty { get; set; }
        public string Priority { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AssignDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public string Statu { get; set; }
    }
}
