using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Visit
    {
        Guest guest; // indgår ikke i constructoren?
        Employee employee;
        Room room;

        DateOnly date;
        TimeOnly startTime;
        TimeOnly endTime;

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
            Console.WriteLine(date);

            Console.WriteLine(startTime +"-"+endTime);
        }
        //Metoder

        public DateOnly GetDate () {
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
