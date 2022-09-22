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
        DateOnly dateRecieved;

        public Guest (string name, string firm, bool recievedSecurityFolder, DateOnly dateRecieved)
        {
            this.name = name;
            this.firm = firm;
            this.recievedSecurityFolder = recievedSecurityFolder;
            this.dateRecieved = dateRecieved;
        }

        public string GetName()
        {
            return name;
        }
        public string GetFirm()
        {
            return firm;
        }

        public bool GetRecievedSecurityFolder()
        {
            return recievedSecurityFolder;
        }

        public DateOnly GetDateRecieved() 
        { 
            return dateRecieved; 
        }
    }
}
