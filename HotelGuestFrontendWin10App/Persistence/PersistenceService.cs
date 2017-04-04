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

        const string serverUrl = "http://hotelguestwebservice20170329095006.azurewebsites.net/";
        //const string serverUrl = "http:// localhost:16908";

        //Her henter (GetAsync) vi gæsterne i Guest-tabellen der ligger i vores HotelDB på Azure,
        //og deserialisere listen af gæster til C#-objekter (ReadAsAsync).
        //public static ObservableCollection<Guest> GetAsyncGuests()
        public static async Task<ObservableCollection<Guest>> GetAsyncGuests()
        {
            ObservableCollection<Guest> TempGuestsCollection = new ObservableCollection<Guest>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringGet = "api/Guests/";

                try
                {
                    //HttpResponseMessage getResponse = client.GetAsync(urlStringGet).Result;
                    HttpResponseMessage getResponse = await client.GetAsync(urlStringGet);

                    if (getResponse.IsSuccessStatusCode)
                    {
                        TempGuestsCollection =await  getResponse.Content.ReadAsAsync<ObservableCollection<Guest>>();
                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return TempGuestsCollection = null;
                }
                /*Har prøvet at få en MessageDialog til at bekræfte at gæsterne er hentet fra databasen, men det lykkedes ikke.*/
                //MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
                return TempGuestsCollection;
            }
        }

        //public async Task<ObservableCollection<Guest>> PostAsyncGuest(Guest newGuest);
        public void PostAsyncGuest(Guest newGuest)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringPost = "api/Guests/";

                try
                {
                    //var postResponse = await client.PostAsJsonAsync<Guest>(urlStringPost, newGuest);
                    var postResponse = client.PostAsJsonAsync<Guest>(urlStringPost, newGuest).Result;

                    if (postResponse.IsSuccessStatusCode)
                    {
                        //Singleton.Instance.PostGuest(newGuest);
                        Singleton.Instance.GuestsCollection.Add(newGuest);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public void PutAsyncGuest(int guest_No, Guest newGuest)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringPost = "api/Guests/{Guest_No}";

                try
                {
                    var postResponse = client.PutAsJsonAsync<Guest>(urlStringPost, newGuest).Result;

                    if (postResponse.IsSuccessStatusCode)
                    {
                        Singleton.Instance.GetGuest(guest_No);
                        Singleton.Instance.PutGuest(guest_No, newGuest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //Her henter (GetAsync) vi View'et GuestNameAndNoOfBookings i vores HotelDB på Azure,
        //og deserialisere listen af gæster til C#-objekter (ReadAsAsync).
        public static async Task<ObservableCollection<GuestNameAndNoOfBookings>> GetTempGuestListDBView()
        {
            ObservableCollection<GuestNameAndNoOfBookings> TempGuestListDBView = new ObservableCollection<GuestNameAndNoOfBookings>();

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringGet = "api/GuestNameAndNoOfBookings/";

                try
                {
                    //HttpResponseMessage getResponse = client.GetAsync(urlStringGet).Result;
                    HttpResponseMessage getResponse = await client.GetAsync(urlStringGet);

                    if (getResponse.IsSuccessStatusCode)
                    {
                        TempGuestListDBView = await getResponse.Content.ReadAsAsync<ObservableCollection<GuestNameAndNoOfBookings>>();
                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                    return TempGuestListDBView = null;
                }
                /*Har prøvet at få en MessageDialog til at bekræfte at gæsterne er hentet fra databasen, men det lykkedes ikke.*/
                //MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
                return TempGuestListDBView;
            }
        }
    }
}
