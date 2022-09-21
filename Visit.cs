using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Visit
    {
        // Felter
        
        DateOnly date;
        TimeOnly startTime;
        TimeOnly endTime;

        Guest guest;
        Employee employee;
        Room room;

        
        public Visit (DateOnly date, TimeOnly startTime, TimeOnly endTime, Guest guest, Employee employee, Room room)
        {

            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.guest = guest;
            this.employee = employee;
            this.room = room;

        }   
        public void show()
        {
            Console.WriteLine("Guest name:          " + guest.GetName()); 

            Console.WriteLine("Date:                " + date.ToString("dd / MM - yyyy"));

            Console.WriteLine("Room name:           " + room.GetName());

            Console.WriteLine("Time:                " + startTime.ToString("HH':'mm") + " - " + endTime.ToString("HH':'mm"));

            Console.WriteLine("Employee name:       " + employee.GetName());

        }
        //Metoder

        public DateOnly GetDate()
        {
            return date;
        }
        
          
        public TimeOnly GetStartTime()
        {
            return startTime;
        }
        public TimeOnly GetEndTime()
        {
            return endTime;
        }

    }

}
