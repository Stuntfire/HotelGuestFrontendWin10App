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


        //GET ---- READ
        //Her henter (GetAsync) vi gæsterne i Guest-tabellen der ligger i vores HotelDB på Azure,
        //og deserialisere listen af gæster til C#-objekter (ReadAsAsync).

        //public static ObservableCollection<Guest> GetGuestsAsync()
        public static async Task<ObservableCollection<Guest>> GetGuestsAsync()
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringGet = "api/Guests/";

                try
                {
                    HttpResponseMessage getResponse = await client.GetAsync(urlStringGet);

                    if (getResponse.IsSuccessStatusCode)
                    {
                        var TempGuestsCollection = await getResponse.Content.ReadAsAsync<ObservableCollection<Guest>>();
                        return TempGuestsCollection;

                        //Besked om succes 
                        MessageDialog guestsLoad = new MessageDialog("The Hotel Guests has been loaded");
                        //guestsLoad.Commands.Add(new UICommand { Label = "Ok" });
                        guestsLoad.ShowAsync();
                    }
                }
                catch (Exception e)
                {
                    MessageDialog exception = new MessageDialog(e.Message);
                }
                /*Har prøvet at få en MessageDialog til at bekræfte at gæsterne er hentet fra databasen, men det lykkedes ikke.*/
                //MessageDialog succes = new MessageDialog($"Gæsterne blev hentet fra databasen via {serverUrl} Hotel Guest Web Service.");
                return null;
            }
        }


        //POST ---- CREATE

        //public async Task<ObservableCollection<Guest>> PostGuestAsync(Guest newGuest);
        public static void PostGuestAsync(Guest newGuest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringPost = "api/Guests/";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //var postResponse = await client.PostAsJsonAsync<Guest>(urlStringPost, newGuest);
                    var postResponse = client.PostAsJsonAsync<Guest>(urlStringPost, newGuest).Result;
                    //var response = client.PostAsJsonAsync<Guest>("api/guests", PostGuest).Result;

                    if (postResponse.IsSuccessStatusCode)
                    {
                        //Besked om POST Success 
                        MessageDialog postGuest = new MessageDialog("New Guests Created");
                        //guestsLoad.Commands.Add(new UICommand { Label = "Ok" });
                        postGuest.ShowAsync();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        //PUT ---- UPDATE

        public static void PutAsyncGuest(int guest_No, Guest newGuest)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringPut = $"api/Guests/{newGuest.Guest_No}";

                try
                {
                    var putResponse = client.PutAsJsonAsync<Guest>(urlStringPut, newGuest).Result;

                    if (putResponse.IsSuccessStatusCode)
                    {
                        //Singleton.Instance.GetGuest(guest_No);
                        //Singleton.Instance.PutGuest(guest_No, newGuest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        //REMOVE ---- DELETE
        public static void DeleteAsyncGuest(/*int Guest_No,*/ Guest deleteGuest)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                string urlStringDelete = $"api/Guests/{deleteGuest.Guest_No}";
                //string urlStringDelete = "api/Guests/" + deleteGuest.Guest_No.ToString();

                try
                {
                    var deleteResponse = client.DeleteAsync(urlStringDelete).Result;

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        //Singleton.Instance.GetGuest(guest_No);
                        //Singleton.Instance.PutGuest(guest_No, newGuest);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        //Database view baseret på Guest

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
