using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketMatchTicketSystem.Biz.ViewModel
{
    public class CustomerViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
        public string Gender { get; set; }
        public int TicketID { get; set; }
        public int SeatID { get; set; }
        public string TicketName { get; set; }
        public string SeatName { get; set; }
    }
}
