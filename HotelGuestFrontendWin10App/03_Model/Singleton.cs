using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App.Persistence;
using HotelGuestFrontendWin10App._03_Model;

namespace HotelGuestFrontendWin10App._03_Model
{
    public class Singleton
    {
        private static Singleton instance;

        public static Singleton Instance 
            {
            get {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public ObservableCollection<Guest> GuestsCollection { get; set; }

        private Singleton()
        {
            GuestsCollection = new ObservableCollection<Guest>();
            GuestsCollection.Clear();
            GuestsCollection = PersistenceService.GetAsyncGuests();
        }

        public void PostGuest(Guest newGuest)
        {
            GuestsCollection.Add(newGuest);
        }

        public void PutGuest(int Guest_No, Guest guest)
        {
            GuestsCollection.Remove(GuestsCollection.FirstOrDefault(x => x.Guest_No == Guest_No));
            GuestsCollection.Add(guest);
        }
    }
}
