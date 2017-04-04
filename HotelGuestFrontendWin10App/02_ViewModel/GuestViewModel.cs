using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._03_Model;
using System.ComponentModel;
using Windows.UI.Popups;
using System.Windows.Input;
using HotelGuestFrontendWin10App.Common;

namespace HotelGuestFrontendWin10App._02_ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        //public string MessageDialogSuccess()
        //{
        //    MessageDialog succes = new MessageDialog("Gæsterne blev hentet fra databasen via Hotel Guest Web Service.");
        //    return succes.ShowAsync;
        //}
        public int Guest_No { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        private ObservableCollection<Guest> guestList;

        public ObservableCollection<Guest> GuestList 
            {
                get { return guestList; }
                set { guestList = value; }
            }

        private ObservableCollection<GuestNameAndNoOfBookings> guestListDBView;

        public ObservableCollection<GuestNameAndNoOfBookings> GuestListDBView {
            get { return guestListDBView; }
            set { guestListDBView = value; }
        }

        public Handler.GuestHandler guestHandler { get; set; }

        public ICommand CreateGuestCommand { get; set; }

        public ICommand RemoveGuestCommand { get; set; }

        public ICommand PutGuestCommand { get; set; }

        private Guest _selectedGuest;

        public Guest SelectedGuest {
            get { return _selectedGuest; }
            set { _selectedGuest = value; OnPropertyChanged(nameof(SelectedGuest)); }
        }

        public GuestViewModel()
        {
            GuestList = Singleton.Instance.GuestsCollection;
            guestHandler = new Handler.GuestHandler(this);
            CreateGuestCommand = new RelayCommand(guestHandler.CreateGuestHandler, null);
            RemoveGuestCommand = new RelayCommand(guestHandler.RemoveGuestHandler, IfGuestListIsEmpty);
            PutGuestCommand = new RelayCommand(guestHandler.PutGuestHandler, null);
            guestListDBView = new ObservableCollection<GuestNameAndNoOfBookings>();
            //MessageDialogSuccess();
        }

        public bool IfGuestListIsEmpty()
        {
            if (GuestList.Count > 0)
                return true;
            return false;
        }

    }
}
