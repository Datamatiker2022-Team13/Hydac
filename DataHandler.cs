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

        public DataHandler(string dataFileName)
        {
            GuestDataFileName = dataFileName;

            if (!File.Exists(dataFileName))
                File.Create(dataFileName).Close();
        }

        public void SaveGuest(List<Guest> guest)
        {
            StreamWriter swGuest = new StreamWriter(GuestDataFileName);

            for (int i = 0; i < guest.Count; i++)
            {
                swGuest.WriteLine(guest[i].MakeTitle());
            }

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
