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
            string message = string.Empty;
            message += "\tDate:                    " + date.ToString("dd / MM - yyyy") + "\n";
            message += "\tTime:                    " + startTime.ToString("HH':'mm") + " - " + endTime.ToString("HH':'mm") + "\n";

            message += "\tGuest name:              " + guest.GetName() + "\n"; 
            message += "\tEmployee name:           " + employee.GetName() + "\n";
            message += "\tRoom name:               " + room.GetName() + "\n";

            message += "\tSafety flyer recieved?   " + safetyFlyerRecieved.ToString() + "\n";
            message += "\tDate recieved            " + safetyFlyerRecievedDate.ToString("dd / MM - yyyy") + "\n";
            return message;
        }
    }

}
