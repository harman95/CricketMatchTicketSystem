using CricketMatchTicketSystem.Biz.Interface;
using CricketMatchTicketSystem.Biz.ViewModel;
using CricketMatchTicketSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.Service
{
    public class TicketService : ITicketService
    {
        CricketTicketSystemEntities _db = new CricketTicketSystemEntities();
        public List<TicketViewModel> Lists()
        {
            var list = new List<TicketViewModel>();
            list = (from a in _db.Tickets
                    select new TicketViewModel
                    {
                        ID = a.ID,
                        Number = a.Number,
                        Price = a.Price
                    }).ToList();
            return list;
        }
        public List<TicketViewModel> GetByID(int id)
        {
            var record = (from a in _db.Tickets
                          where a.ID == id
                          select new TicketViewModel
                          {
                              ID = a.ID,
                              Number = a.Number,
                              Price = a.Price
                          }).ToList();
            return record;
        }
        public TicketViewModel AddAndUpdate(TicketViewModel viewModel)
        {
            if (viewModel.ID > 0)
            {
                var record = _db.Tickets.Where(x => x.ID == viewModel.ID).FirstOrDefault();
                record.Number = viewModel.Number;
                record.Price = viewModel.Price;
                _db.SaveChanges();

            }
            else
            {
                Ticket _ticket = new Ticket();
                _ticket.Number = viewModel.Number;
                _ticket.Price = viewModel.Price;
                _db.Tickets.Add(_ticket);
                _db.SaveChanges();
                viewModel.ID = _ticket.ID;
            }
            return viewModel;
        }
        public bool Delete(int id)
        {
            bool isDeleted = false;
            var record = _db.Tickets.Where(x => x.ID == id).FirstOrDefault();
            _db.Tickets.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
