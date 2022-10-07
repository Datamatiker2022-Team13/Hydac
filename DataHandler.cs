using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class DataHandler
    {
        public string filePath { get; }

        public DataHandler(string filePath)
        {
            this.filePath = filePath;

            if (!File.Exists(filePath))
                File.Create(filePath).Close();
        }

        public void SaveGuests(List<Guest> guest)
        {
            StreamWriter swGuest = new StreamWriter(filePath);

            for (int i = 0; i < guest.Count; i++)
            {
                swGuest.WriteLine(guest[i].MakeTitle());
            }

            swGuest.Close();
        }
        public List<Guest> LoadGuests()
        {
            List<Guest> guestList = new List<Guest>();


            StreamReader sr = new StreamReader(filePath);
            while (sr.EndOfStream == false)
            {
                string[] guestLine = sr.ReadLine().Split(';');

                guestList.Add(new Guest(guestLine[0], guestLine[1], guestLine[2]));


            }
            sr.Close();
                return guestList;
        }

        public void SaveVisits(List <Visit> visit)
        {
            StreamWriter swGuest = new StreamWriter(filePath);

            for (int i = 0; i < visit.Count; i++)
            {
                swGuest.WriteLine(visit[i].MakeTitle());
            }

            swGuest.Close();
        }

        public List<Visit> LoadVisits()
        {
            List<Visit> visitList = new List<Visit>();


            StreamReader sr = new StreamReader(filePath);
            while (sr.EndOfStream == false)
            {
                string[] visitLine = sr.ReadLine().Split(';');

                Employee employee = null;
                foreach (Employee listEmployee in Program.employees)
                {
                    if (listEmployee.Name == visitLine[6])
                    {
                        employee = listEmployee;
                        break;
                    }
                }

                Room room = null;
                foreach (Room listRoom in Program.rooms)
                {
                    if (listRoom.Name == visitLine[7])
                    {
                        room = listRoom;
                        break;
                    }
                }
                visitList.Add(new Visit(
                    DateOnly.Parse(visitLine[0]), 
                    TimeOnly.Parse(visitLine[1]), 
                    TimeOnly.Parse(visitLine[2]), 
                    new Guest(visitLine[3], visitLine[4], visitLine[5]),
                    employee, 
                    room, 
                    bool.Parse(visitLine[8])));



            }
            sr.Close();
            return visitList;
        }
    }
}
