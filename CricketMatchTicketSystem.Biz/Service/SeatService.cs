using CricketMatchTicketSystem.Biz.Interface;
using CricketMatchTicketSystem.Biz.ViewModel;
using CricketMatchTicketSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchSeatSystem.Biz.Service
{
   public class SeatService:ISeatService
    {
        CricketTicketSystemEntities _db = new CricketTicketSystemEntities();
        public List<SeatViewModel> Lists()
        {
            var list = new List<SeatViewModel>();
            list = (from a in _db.Seats
                    select new SeatViewModel
                    {
                        ID = a.ID,
                        SeatNumber = a.SeatNumber,
                        SeatSide = a.SeatSide
                    }).ToList();
            return list;
        }
        public List<SeatViewModel> GetByID(int id)
        {
            var record = (from a in _db.Seats
                          where a.ID == id
                          select new SeatViewModel
                          {
                              ID = a.ID,
                              SeatNumber = a.SeatNumber,
                              SeatSide = a.SeatSide
                          }).ToList();
            return record;
        }
        public SeatViewModel AddAndUpdate(SeatViewModel viewModel)
        {
            if (viewModel.ID > 0)
            {
                var record = _db.Seats.Where(x => x.ID == viewModel.ID).FirstOrDefault();
                record.SeatNumber = viewModel.SeatNumber;
                record.SeatSide = viewModel.SeatSide;
                _db.SaveChanges();

            }
            else
            {
                Seat _seat = new Seat();
                _seat.SeatNumber = viewModel.SeatNumber;
                _seat.SeatSide = viewModel.SeatSide;
                _db.Seats.Add(_seat);
                _db.SaveChanges();
                viewModel.ID = _seat.ID;
            }
            return viewModel;
        }
        public bool Delete(int id)
        {
            bool isDeleted = false;
            var record = _db.Seats.Where(x => x.ID == id).FirstOrDefault();
            _db.Seats.Remove(record);
            _db.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }
    }
}
