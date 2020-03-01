using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.Interface
{
    public interface ISeatService
    {
        List<SeatViewModel> Lists();
        List<SeatViewModel> GetByID(int id);
        SeatViewModel AddAndUpdate(SeatViewModel viewModel);
        bool Delete(int id);
    }
}
