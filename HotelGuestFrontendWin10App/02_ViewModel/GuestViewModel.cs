using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._03_Model;
using System.ComponentModel;
using Windows.UI.Popups;

namespace HotelGuestFrontendWin10App._02_ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        //public string MessageDialogSuccess()
        //{
        //    MessageDialog succes = new MessageDialog("Gæsterne blev hentet fra databasen via Hotel Guest Web Service.");
        //    return succes.ShowAsync;
        //}
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
            //MessageDialogSuccess();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
