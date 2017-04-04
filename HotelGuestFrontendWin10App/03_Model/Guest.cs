using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestFrontendWin10App._03_Model
{
    public class Guest
    {
        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Guest(int guest_no, string name, string address)
        {
            this.Guest_No = guest_no;
            this.Name = name;
            this.Address = address;
        }

        public override string ToString()
        {
            return $"Guest #: {Guest_No}, Name: {Name}, Address: {Address}";
        }
    }
}
