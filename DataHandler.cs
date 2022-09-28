using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class DataHandler
    {
        public string GuestDataFileName { get; }

        public DataHandler(string guestDataFileName)
        {
            GuestDataFileName = guestDataFileName;
        }

        public void SaveGuest(Guest guest)
        {
            StreamWriter swGuest = new StreamWriter(GuestDataFileName);
            swGuest.WriteLine(guest.MakeTitle());

            swGuest.Close();
        }
        public List<Guest> LoadGuest()
        {
            List<Guest> guestList = new List<Guest>();


            StreamReader sr = new StreamReader(GuestDataFileName);
            while (sr.EndOfStream == false)
            {
                string[] guestLine = sr.ReadLine().Split(';');

                guestList.Add(new Guest(guestLine[0], guestLine[1], guestLine[2]));

            }
            sr.Close();
                return guestList;
        }


    }
}
