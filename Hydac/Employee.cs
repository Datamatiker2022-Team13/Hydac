﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydac
{
    internal class Employee
    {
        string navn; 
        string occupation;

        public string GetName ()
        {
              // skal returnere navnet
            return navn;
        }

        public string GetOccupation()
        {
<<<<<<< refs/remotes/origin/Visit
            throw new NotImplementedException();
=======
            // skal returnere stillingsbetegnelse 
            return occupation;
>>>>>>> Final formatting
        }
    }
}