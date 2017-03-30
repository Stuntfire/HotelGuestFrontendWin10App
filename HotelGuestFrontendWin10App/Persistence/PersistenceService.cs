using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._03_Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Popups;

namespace HotelGuestFrontendWin10App.Persistence
{
    class PersistenceService
    {
        const string serverUrl = "http://hotelguestwebservice20170329095006.azurewebsites.net/";
        public static ObservableCollection<Guest> GetAsyncGuests()
        {
            ObservableCollection<Guest> TempGuestsCollection = new ObservableCollection<Guest>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringGet = "api/Guests";

                try
                {
                    HttpResponseMessage response = client.GetAsync(urlStringGet).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        TempGuestsCollection = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;
                        MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
                    }
                }
                catch (Exception e)
                {
                    TempGuestsCollection = null;
                    MessageDialog exception = new MessageDialog(e.Message);
                }

                return TempGuestsCollection;
            }
        }
    }
}
