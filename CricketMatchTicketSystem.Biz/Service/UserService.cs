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
    public class UserService : IUserService
    {
        CricketTicketSystemEntities _db = new CricketTicketSystemEntities();
        public bool LoginUser(UserViewModel model)
        {
            bool isLogin = false;
            try
            {
                var record = (from a in _db.Users
                              where a.Name == model.Name && a.Password == model.Password
                              select a).Count() > 0 ? true : false;
                if (record)
                {
                    isLogin = true;
                }
            }
            catch (Exception ex)
            {

            }
            return isLogin;
        }
    }
}
