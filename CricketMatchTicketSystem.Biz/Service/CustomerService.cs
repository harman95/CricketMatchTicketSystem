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
    public class CustomerService : ICustomerService
    {
        //For List
        CricketTicketSystemEntities _db = new CricketTicketSystemEntities();
        public List<CustomerViewModel> Lists()
        {
            var list = new List<CustomerViewModel>();
            list = (from a in _db.Customers
                    join b in _db.Tickets on a.TicketID equals b.ID
                    join c in _db.Seats on a.SeatID equals c.ID
                    select new CustomerViewModel
                    {
                        ID = a.ID,
                        Name = a.Name,
                        EmailID = a.EmailID,
                        MobileNumber = a.MobileNumber,
                        TicketID = a.TicketID,
                        SeatID = a.SeatID,
                        TicketName = b.Number + "( " + b.Price + ")",
                        SeatName = c.SeatNumber + "( " + c.SeatSide + ")"
                    }).ToList();
            return list;
        }
        public List<CustomerViewModel> GetByID(int id)
        {
            var record = (from a in _db.Customers
                          where a.ID == id
                          select new CustomerViewModel
                          {
                              ID = a.ID,
                              Name = a.Name,
                              EmailID = a.EmailID,
                              MobileNumber = a.MobileNumber,
                              TicketID = a.TicketID,
                              SeatID = a.SeatID
                          }).ToList();
            return record;
        }
        public CustomerViewModel AddAndUpdate(CustomerViewModel viewModel)
        {
            if (viewModel.ID > 0)
            {
                var record = _db.Customers.Where(x => x.ID == viewModel.ID).FirstOrDefault();
                record.Name = viewModel.Name;
                record.EmailID = viewModel.EmailID;
                record.MobileNumber = viewModel.MobileNumber;
                record.TicketID = viewModel.TicketID;
                record.SeatID = viewModel.SeatID;
                _db.SaveChanges();

            }
            else
            {
                Customer _customer = new Customer();
                _customer.Name = viewModel.Name;
                _customer.EmailID = viewModel.EmailID;
                _customer.MobileNumber = viewModel.MobileNumber;
                _customer.TicketID = viewModel.TicketID;
                _customer.SeatID = viewModel.SeatID;
                _db.Customers.Add(_customer);
                _db.SaveChanges();
                viewModel.ID = _customer.ID;
            }
            return viewModel;
        }
        public bool Delete(int id)
        {
            bool isDeleted = false;
            var record = _db.Customers.Where(x => x.ID == id).FirstOrDefault();
            _db.Customers.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
