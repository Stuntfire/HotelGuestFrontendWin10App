using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestFrontendWin10App._03_Model
{
    public class GuestNameAndNoOfBookings
    {
        public string Name { get; set; }

        public int? NoOfBookings { get; set; }

        public override string ToString()
        {
            return $"{this.Name} har lavet {this.NoOfBookings} booking(s).";
        }
    }
}
