using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestFrontendWin10App._03_Model
{
    public class Singleton
    {
        private static Singleton instance;

        

        public static Singleton Instance {
            get {
                if (Instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public ObservableCollection<Guest> Guests { get; set; }

        private Singleton()
        {
            Guests = new ObservableCollection<Guest>();
        }

    }
}
