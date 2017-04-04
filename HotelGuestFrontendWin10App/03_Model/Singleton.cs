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
            //GuestsCollection.Clear();
            //var liste = GuestsCollection = PersistenceService.GetAsyncGuests().Result;

            GetGuestsAsync();
            //GuestsCollection = PersistenceService.GetAsyncGuests();
        }

        /* Herunder laver vi 4 metoder der skal understøtte vores CRUD WebService:
         Create = PostGuest
         Read = GetGuest
         Update = PutGuest
         Delete = RemoveGuestHandler */

        // POST (Create) en ny Guest
        public void PostGuest(Guest newGuest)
        {
            GuestsCollection.Add(newGuest);
        }

        // GET (Read) specifik Guest via Guest_No
        public Guest GetGuest(int guest_No)
        {
            return GuestsCollection.First(x => x.Guest_No == guest_No);
        }

        public async Task GetGuestsAsync()
        {
            //this.GuestsCollection = await PersistenceService.GetAsyncGuests();

            // Kan ikke forstå at et kald 
            foreach (var item in await PersistenceService.GetAsyncGuests())
            {
                this.GuestsCollection.Add(item);
            }
        }


        //// GET specifik Guest via Guest_No
        //public static ObservableCollection<Guest> GetGuestsCollection()
        //{
        //    return GuestsCollection;
        //}

        // PUT (update) en ny Guest
        public void PutGuest(int guest_No, Guest guest)
        {
            GuestsCollection.Remove(GuestsCollection.FirstOrDefault(x => x.Guest_No == guest_No));
            GuestsCollection.Add(guest); // er i tvivl om hvilken en af dem der er den rigtige metode at benytte...
            //GuestsCollection.Insert(guest_No, guest);
        }

        // REMOVE (Delete) en Guest
        public void RemoveGuest(int guest_No)
        {
            GuestsCollection.Remove(GuestsCollection.FirstOrDefault(x => x.Guest_No == guest_No));
        }
    }
}
