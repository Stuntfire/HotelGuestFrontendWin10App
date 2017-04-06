using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._02_ViewModel;
using HotelGuestFrontendWin10App._03_Model;

namespace HotelGuestFrontendWin10App.Handler
{
    public class GuestHandler
    {
        private GuestViewModel Gvm { get; set; }

        public GuestHandler(GuestViewModel gvm)
        {
            this.Gvm = gvm;
        }

        public void CreateGuestHandler()
        {
            Guest tempGuest = new Guest(Gvm.Guest_No, Gvm.Name, Gvm.Address);
            tempGuest.Guest_No = Gvm.Guest_No;
            tempGuest.Name = Gvm.Name;
            tempGuest.Address = Gvm.Address;
            Singleton.Instance.PostGuest(tempGuest);
        }

        public void PutGuestHandler()
        {
            Singleton.Instance.PutGuest(Gvm.Guest_No, Gvm.SelectedGuest);
        }

        public void RemoveGuestHandler()
        {
            Singleton.Instance.RemoveGuest(Gvm.SelectedGuest);
        }

        public async void GetGuestHandler()
        {
            await Singleton.Instance.GetGuestsAsync();
        }


    }
}
