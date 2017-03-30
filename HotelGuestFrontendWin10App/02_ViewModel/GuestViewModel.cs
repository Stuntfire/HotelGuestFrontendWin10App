using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._03_Model;

namespace HotelGuestFrontendWin10App._02_ViewModel
{
    class GuestViewModel
    {
        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        private ObservableCollection<Guest> guestList;

        public ObservableCollection<Guest> GuestList {
            get { return guestList; }
            set { guestList = value; }
        }

        public GuestViewModel()
        {
            GuestList = Singleton.Instance.GuestsCollection;
        }

    }
}
