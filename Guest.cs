using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Guest
    {
        string name;
        string firm;
        bool recievedSecurityFolder;
        int dateRecievedDay;
        int dateRecievedMonth;
        int dateRecievedYear;
        
        public Guest (string name, string firm, bool recievedSecurityFolder, int year, int month, int day)
        {
            this.name = name;
            this.firm = firm;
            this.recievedSecurityFolder = recievedSecurityFolder;
            dateRecievedYear = year;
            dateRecievedMonth = month;
            dateRecievedDay = day;
        }

        public string GetName()
        {
            return name;
        }
        public string GetFirm()
        {
            return firm;
        }

        public bool GetSecurityFolder()
        {
            return recievedSecurityFolder;
        }

        public int GetDateRecievedDay() 
        { 
            return dateRecievedDay; 
        }
        
        public int GetDateRecievedDate() 
        { 
            return dateRecievedMonth; 
        }

        public int GetDateRecievedYear() 
        { 
            return dateRecievedYear; 
        }
        public void AddNewGuest(string name, string firm, bool folder, int year, int month, int day)
        {
            Guest mi = new Guest(name, firm, folder, year, month, day);  


        }
    }
}
