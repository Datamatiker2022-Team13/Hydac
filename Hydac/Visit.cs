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
        Guest visitor;
        int day;
        int month;
        int year;

        int startTime;
        int endTime;

        public Visit (int day, int month, int year, int startTime, int endTime)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            this.startTime = startTime;
            this.endTime = endTime;
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
        public int GetStartTime()
        {
            return startTime;
        }
        public int GetEndTime()
        {
            return endTime;
        }

    }

}
