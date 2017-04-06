using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using HotelGuestFrontendWin10App._01_View;
using HotelGuestFrontendWin10App._02_ViewModel;
using HotelGuestFrontendWin10App._03_Model;
using HotelGuestFrontendWin10App.Common;
using HotelGuestFrontendWin10App.Handler;
using HotelGuestFrontendWin10App.Persistence;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace UnitTestGuest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetNumbersOfGuestsFail()
        {
            ObservableCollection<Guest> testCollection = new ObservableCollection<Guest>();
            testCollection = PersistenceService.GetGuestsAsync().Result;
            //Forventer en Fail, da der er 34 gæster på listen pt.
            Assert.AreEqual(33, testCollection.Count);
        }

        [TestMethod]
        public void GetNumbersOfGuestsSuccess()
        {
            ObservableCollection<Guest> testCollection = new ObservableCollection<Guest>();
            testCollection = PersistenceService.GetGuestsAsync().Result;
            //Forventer en Success, da der er 34 gæster på listen pt.
            Assert.AreEqual(34, testCollection.Count);
        }

    }
}
