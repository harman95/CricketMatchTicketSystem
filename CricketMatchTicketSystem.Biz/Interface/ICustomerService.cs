using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.Interface
{
    public interface ICustomerService
    {

        List<CustomerViewModel> Lists();
        List<CustomerViewModel> GetByID(int id);
        CustomerViewModel AddAndUpdate(CustomerViewModel viewModel);
        bool Delete(int id);
    }
}
