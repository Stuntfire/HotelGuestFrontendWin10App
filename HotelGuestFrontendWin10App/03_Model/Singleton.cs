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


        // SINGLETON CONSTRUCTOR
        private Singleton()
        {
            GuestsCollection = new ObservableCollection<Guest>();

            GetGuestsAsync();
        }

        /* Herunder laver vi 4 metoder der skal understøtte vores CRUD WebService:
         Create = PostGuest
         Read = GetGuest
         Update = PutGuest
         Delete = RemoveGuestHandler */

        // Create/POST en ny Guest
        public void PostGuest(Guest newGuest)
        {
            PersistenceService.PostGuestAsync(newGuest);
            GuestsCollection.Add(newGuest);
        }


        // Read/GET listen af Guests
        public async Task GetGuestsAsync()
        {
            //this.GuestsCollection = await PersistenceService.GetGuestsAsync();

            // Kan ikke forstå hvorfor et response skal foreach'es?
            foreach (var item in await PersistenceService.GetGuestsAsync())
            {
                this.GuestsCollection.Add(item);
            }
        }
        public Guest GetGuest(int guest_No)
        {
            return GuestsCollection.First(x => x.Guest_No == guest_No);
        }

        //// GET specifik Guest via Guest_No
        //public static ObservableCollection<Guest> GetGuestsCollection()
        //{
        //    return GuestsCollection;
        //}

        // Update/PUT en Guest
        public void PutGuest(int guest_No, Guest newGuest)
        {
            PersistenceService.PutAsyncGuest(guest_No, newGuest);
            GuestsCollection.Clear();
            GetGuestsAsync();
        }

        // Delete/REMOVE en Guest
        public void RemoveGuest(/*int Guest_No,*/ Guest deleteGuest)
        {
            if (deleteGuest != null)
            {
                GuestsCollection.Remove(deleteGuest);
                PersistenceService.DeleteAsyncGuest(/*Guest_No,*/ deleteGuest);
            }
        }
    }
}
