using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketTracingSystemApp.Models;

namespace TicketTracingSystemApp.Repositories
{
    public class TicketRepository
    {
        private readonly ApplicationDbContext _db;
        public TicketRepository()
        {
            _db = new ApplicationDbContext();
        }

        public void Add(Ticket product)
        {
            _db.Tickets.Add(product);
            _db.SaveChanges();
        }

        public Ticket Find(string id)
        {
            return _db.Tickets.Find(id);
        }

        public List<Ticket> List()
        {
            return _db.Tickets.ToList();
        }


        public void Delete(string id)
        {
            var entity = Find(id);
            _db.Tickets.Remove(entity);
            _db.SaveChanges();
        }

        public void Update(Ticket p)
        {
            _db.Tickets.Update(p);
            _db.SaveChanges();
        }
    }
}
