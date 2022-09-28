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

        bool safetyFlyerRecieved;
        DateOnly safetyFlyerRecievedDate;
        
        public Visit (DateOnly date, TimeOnly startTime, TimeOnly endTime, Guest guest, Employee employee, Room room, bool safetyFlyerRecieved, DateOnly safetyFlyerRecievedDate)
        {
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;

            this.guest = guest;
            this.employee = employee;
            this.room = room;

            this.safetyFlyerRecieved = safetyFlyerRecieved;
            this.safetyFlyerRecievedDate = safetyFlyerRecievedDate;
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

        public bool GetSafetyFlyerRecieved () 
        {
            return safetyFlyerRecieved;
        }

        public DateOnly GetSafetyFlyerRecievedDate () {
            return safetyFlyerRecievedDate;
        }

        public override string ToString()
        {
            return string.Format("\t{0,-20} {1,-20} {2,-20} {3,-20} {4,-20} {5,-20} {6,-20}", 
                date.ToString("dd / MM - yyyy"),
                startTime.ToString("HH':'mm") + " - " + endTime.ToString("HH':'mm"), 
                guest.GetName(), 
                employee.GetName(), 
                room.GetName(),
                safetyFlyerRecieved.ToString(),
                safetyFlyerRecievedDate.ToString("dd / MM - yyyy"));
        }
    }

}
