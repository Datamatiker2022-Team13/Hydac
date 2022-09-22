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
        // Felter
        // mangler employee

        Guest visitor; // indgår ikke i constructoren?
        int day;
        int month;
        int year;

        TimeOnly startTime;
        TimeOnly endTime;

        string visitor1 = "Mathias";
        string employee = "Mathias";

        public Visit (int day, int month, int year, TimeOnly startTime, TimeOnly endTime, string employee)
        {
            //this.visitor = visitor;
            this.employee = employee;
            
            this.day = day;
            this.month = month;
            this.year = year;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public void show()
        {
            Console.WriteLine(day +"/"+ month + "-" + year);

            Console.WriteLine(startTime +"-"+endTime);
        }
        //Metoder

        public int GetDay()
        {
            return day;
        }

        public int GetMonth()
        {
            return month;
        }
        public int GetYear()
        {
            return year;
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
