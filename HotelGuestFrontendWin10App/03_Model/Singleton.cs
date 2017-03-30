using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelGuestFrontendWin10App._03_Model
{
    public class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton Instance {
            get {
                if (Instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

    }
}
