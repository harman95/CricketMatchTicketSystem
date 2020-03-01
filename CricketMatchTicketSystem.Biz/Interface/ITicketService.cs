using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.Interface
{
    public interface ITicketService
    {
        List<TicketViewModel> Lists();
        List<TicketViewModel> GetByID(int id);
        TicketViewModel AddAndUpdate(TicketViewModel viewModel);
        bool Delete(int id);
    }
}
