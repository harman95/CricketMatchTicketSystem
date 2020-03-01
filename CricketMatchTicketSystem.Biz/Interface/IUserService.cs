using CricketMatchTicketSystem.Biz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.Interface
{
    public interface IUserService
    {
        bool LoginUser(UserViewModel model);
    }
}
