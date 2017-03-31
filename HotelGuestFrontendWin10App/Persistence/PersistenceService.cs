using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelGuestFrontendWin10App._03_Model;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Popups;
using System.Net.Http.Headers;

namespace HotelGuestFrontendWin10App.Persistence
{
    public class PersistenceService
    {

        //public void MessageDialogSuccess()
        //{
        //    MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
        //    //return succes;
        //}

        const string serverUrl = "http://hotelguestwebservice20170329095006.azurewebsites.net";
        //const string serverUrl = "http:// localhost:16908";

        //Her henter (GetAsync) vi gæsterne i Guest-tabellen der ligger i vores HotelDB på Azure,
        //og deserialisere listen af gæster til C#-objekter (ReadAsAsync).
        public static ObservableCollection<Guest> GetAsyncGuests()
        {
            ObservableCollection<Guest> TempGuestsCollection = new ObservableCollection<Guest>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringGet = "api/Guests";
 
                try
                {
                    HttpResponseMessage response = client.GetAsync(urlStringGet).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        TempGuestsCollection = response.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;
                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return TempGuestsCollection = null;
                }
                //MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
                return TempGuestsCollection;
            }
        }

        //Her 
    }
}
